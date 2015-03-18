using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class counter : MonoBehaviour {
	[SerializeField]
	private int score;
	private int hitsCount;
	private int greatCount;
	private int goodCount;
	public Timer tm;

	public Text greatHitsText;
	public Text goodHitsText;
	public Text ShootsText;
	public Text MissText;
	public Text RateText;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		score = 0;
		hitsCount=0;
		greatCount=0;
		goodCount=0;
		goodHitsText.text = "Good:" + goodCount;
		greatHitsText.text = "Great:" + greatCount;
		ShootsText.text = "Shoot:" + hitsCount;
		MissText.text = "Miss:"+(hitsCount - goodCount - greatCount);
		RateText.text = "Rate:"+"0%";
	}
	/**
	 * ここでスコアとか撃った回数とかを制御する
	 *@param cnt 
	 */
	public void setScore(int cnt){
		if(cnt == 1){
			this.goodHitsCount();
			this.scoreCount();
		}else if(cnt == 2){
			this.greatHitsCount();
			this.scoreCount();
		}else if(cnt<0){
			this.scoreCount();
		}
		score += cnt;
		hitsCount++;
		shootCount();
		missCount();
		ratePercent();
		if(hitsCount==1){
			SoundManager.Instance.PlayBGM(1);
			tm.check();
		}
		print (cnt+"点にあたったお");
		print ("現在"+score+"スコアだお");
		print ("合計"+hitsCount+"回撃ったお");
	}
	public void oneMoreSetCount(){
		score = 0;
		hitsCount = 0;
		greatCount=0;
		goodCount=0;
		goodHitsText.text = "Good:" + goodCount;
		greatHitsText.text = "Great:" + greatCount;
		ShootsText.text = "Shoot:" + hitsCount;
		MissText.text = "Miss:"+(hitsCount - goodCount - greatCount);
		RateText.text = "Rate:"+"0%";
		scoreText.text = "text:"+"点";
	}

	public void greatHitsCount(){
		greatCount++;
		greatHitsText.text = "Great:" + greatCount;

	}
	public void goodHitsCount(){
		goodCount++;
		goodHitsText.text = "Good:" + goodCount;
	}
	public void shootCount(){
		ShootsText.text = "Shoot:" + hitsCount;
	}
	public void missCount(){
		MissText.text = "Miss:" + (hitsCount - goodCount - greatCount);
	}
	public void ratePercent(){
		RateText.text = "Rate:" + (((float)(goodCount+greatCount)/(float)hitsCount)*100).ToString("f1")+"%";
	}
	public void scoreCount(){
		scoreText.text = "Score:"+(goodCount+(greatCount*2)-((hitsCount-goodCount-greatCount)*2))+"点";
	}
}
