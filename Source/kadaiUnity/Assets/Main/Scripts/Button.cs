using UnityEngine;
using System.Collections;
[RequireComponent(typeof(MeshCollider))]
public class Button : MonoBehaviour {
    private Transform button;
    public int count = 1;
    public int Score = 0;
    public bool isNowDragging;

    private int a = 0;

    public countDownTimer cDT;
	// Use this for initialization
	void Start () {
        button = this.gameObject.transform;
        isNowDragging = true;
	}
    
    public void finished(){
        
        if (a == 0) {
            isNowDragging = false;
            a++;
            SoundManager.Instance.PlaySE(2);
            Score = count-1;
            count = 0;
        }
    }

    //計算抜きで自分のメッシュの上でクリックされたか調べられる 
    void OnMouseDown() {
        if (isNowDragging&&cDT.timeMinus) {
            count++;
            this.button.transform.localPosition = new Vector3(0f, 0.013f, 0f);
            print(count);
            SoundManager.Instance.StopSE();
            SoundManager.Instance.PlaySE(0);
        }
    }

    void OnMouseUp() {
        if (isNowDragging&&cDT.timeMinus) {
            this.button.transform.localPosition = new Vector3(0f, 0.014f, 0f);
            SoundManager.Instance.StopSE();
            SoundManager.Instance.PlaySE(1);
        }
    }


}
