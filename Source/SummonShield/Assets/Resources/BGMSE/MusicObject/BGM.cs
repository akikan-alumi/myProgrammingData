using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //ノーマルシーンが始まるとBGMがなる
        SoundManager.Instance.PlayBGM(0);
	}
	
	// Update is called once per frame
	public void SetBOSSBGM () {//ボスが来たらボス曲を再生
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlaySE(3);
        SoundManager.Instance.PlayBGM(1);
	}
    public void SetNormalBGM() {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(0);
    }
}
