using UnityEngine;
using System.Collections;


public class Spawns : MonoBehaviour {

	private int count = 0;
	private int spawnSpace;
	[SerializeField]
	public GameObject[] enemy;
	[SerializeField]
	private int startTime = 0;
	private float nowTime = 0f;
	private int level = 0;
	public GameObject ResultObj;
	private Result result;
	public int[] spaseLevel = {100,90,80,70,60,50,100};

	void Start(){
		result = ResultObj.GetComponent<Result> ();
	}

	// Update is called once per frame
	void Update () {
		count++;
		nowTime += Time.deltaTime;
		spawnSpace = spaseLevel [level];
		level = result.getSentLevel();

		//スポーン間隔を満たしたら && 一時停止状態じゃないときスポーンする
		if (count >= spawnSpace && Time.timeScale != 0 && nowTime >= (float)startTime && GameObject.Find("BossEnemy1") == null ) {
						
			count = 0;
			Instantiate (enemy[level], this.transform.localPosition, this.transform.localRotation);
			//Debug.Log (level);
				
		} else if(Time.timeScale != 1){
			count = 0;	
		}
	}

	/// <summary>
	/// エネミーのゲッター
	/// </summary>
	/// <value>The sent enemy.</value>
	public GameObject[] Enemy{
		get{return enemy;}
	}
    public int Levels {
        get { return level; }
    }
}