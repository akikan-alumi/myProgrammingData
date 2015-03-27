using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour {

	public GameObject[] enemy;
	public GameObject ResultObj;
	private int level = 0;
    private Result result;
    private int endCount;
    void Start() {
        result = ResultObj.GetComponent<Result>();
       // endCount = 0;
    }

	void Update(){
		level = result.getSentLevel();
		}
	// ボスをスポーンさせる
	public void bossSpawn () {
		Debug.Log ("endCount:"+endCount);
		if(GameObject.Find("BossEnemy1(Clone)") == null /*&& endCount<6*/){ 
        	Instantiate(enemy[level], this.transform.localPosition, this.transform.localRotation);
           // endCount++;
		}
     }
}