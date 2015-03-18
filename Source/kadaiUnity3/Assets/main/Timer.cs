using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float myTimer = 30f;
	public ChangeCamera cc;
	public bool swit = false;

	public Text nowTime;

	public counter cnt;
	public GreatHits gh;
	// Use this for initialization
	void Start () {
		nowTime.text = myTimer.ToString("f1");
	}

	// Update is called once per frame
	void Update () {

		if(swit && myTimer > 0){
			myTimer -= Time.deltaTime;
		}
		nowTime.text = myTimer.ToString("f1");
		if(myTimer<=0){
			if(cc.mainCamera){

			cc.resultGame();
			print ("Timer is not plus");

			}
		}
	}

	public void check(){
		swit = true;
	}
	public void onemore(){
		if(myTimer<0){
			swit = false;
			myTimer = 30f;
			cc.switching();
			cc.playingStart();
			cnt.oneMoreSetCount();
			gh.zeroPos();
			cc.playingStart();
		}
	}
}
