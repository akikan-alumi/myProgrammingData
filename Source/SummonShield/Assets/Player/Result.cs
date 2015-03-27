using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Result : MonoBehaviour {
	
	// 初期値セット
	private float score = 0f;
	private float tempScore = 0f;
	private float dateTime = 0f;
	[SerializeField] 
	private GameObject resultView;
	[SerializeField]
	private GameObject scoreTextObj;
	[SerializeField]
	private GameObject canvas;
	[SerializeField]
	private GameObject nowScoreTextObj;
	public GameObject conTextObj;
	private Text nowScoreText;
	private Text scoreText;
	private Text conText;
	[SerializeField]
	private float addSpeed = 0.125f;
	public GameObject[] spawners;
	private bool gameOver;
	private string strScore;
	private static float highScore;
	private ClickPositionCreatePrefabScript stopFlg;
	[SerializeField]
	private GameObject ClickObj;
	public float[] levelLine = {1000,2000,3000,4000,5000,6000,7000};
	private float line = 0;
	private int level = 0;
	//private int enemySu;
	private Spawns spawns;
	public GameObject spawnsObj;
	private GameObject[] circuits;
	private int end;
	public GameObject bossSpwanerObj;
	private BossSpawner bossSpawner; 
	private static int conLevel;
	private bool lastFlg = false;
    public GameObject continueButton;
	void Awake(){
		score = 0;
		level = 0;
		line = 0;
		if (conLevel != null) {
			level = conLevel;
		}
		line = score + levelLine [level];
		Debug.Log (level);
	}
	
	void Start(){
		bossSpawner = bossSpwanerObj.GetComponent<BossSpawner> ();
		spawns = spawnsObj.GetComponent<Spawns> ();
		highScore = PlayerPrefs.GetFloat ("highScore");
		//enemySu = spawns.sentEnemy;
		stopFlg = ClickObj.GetComponent<ClickPositionCreatePrefabScript> ();
		scoreText = scoreTextObj.GetComponent<Text> ();
		nowScoreText = nowScoreTextObj.GetComponent<Text> ();
		gameOver = false;
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		circuits = GameObject.FindGameObjectsWithTag("Circuit");
		conText = conTextObj.GetComponent<Text>();
	}
	
	void Update ()
	{
		if(gameOver == false){
			dateTime += Time.deltaTime;
			tempScore = dateTime;
			score = tempScore * addSpeed; 
			strScore = score.ToString("F0");
			nowScoreText.text = "" + strScore;
			if(score >= line && GameObject.Find("BossEnemy1(Clone)") == null && lastFlg == false){
				bossSpawner.bossSpawn();
				if(level == spawns.enemy.Length-1){
					lastFlg = true;
				}
				//change();
				Debug.Log ("level"+level);
				Debug.Log ("line"+line);
			}
			//Debug.Log (dateTime);
		}
	}
	
	public void GameOver()
	{
		circuits = GameObject.FindGameObjectsWithTag("Circuit");
		gameOver = true;
		foreach (GameObject cir in circuits) {
			Destroy(cir);
		}
		canvas.SetActive (false);
		resultView.SetActive (true);
		
		stopFlg.sentFlg = 1;
		Time.timeScale = 0;
		scoreText.text = "score:" + strScore;
		conTextObj.SetActive(false);
		if((highScore < score) || (highScore == null)){
			highScore = score;
			PlayerPrefs.SetFloat("highScore",highScore);
		}
		conLevel = level;
		Debug.Log ("level"+level);
		Debug.Log ("line"+line);
		Debug.Log ("conLevel:" + conLevel);
	}
	
	public void change(){
		Debug.Log ("Congratulations + 現在のlevel" + level);
		if (level < spawns.enemy.Length) {
			level++;
			line = score + levelLine[level];
			Debug.Log ("conLevel:" + conLevel);
		} else {
			//		level = 0;
		}
	}
	public void congratulations () {//全クリしたら spawns.enemy.Length は6
		foreach (GameObject spa in spawners) {
			Destroy(spa);
		}
		conLevel = 0;
		canvas.SetActive (false);
        continueButton.SetActive(false);
		resultView.SetActive (true);	
		stopFlg.sentFlg = 1;
		Time.timeScale = 0;
		scoreText.text = "score:" + strScore;
		conText.text = "Congratulations!!";
		conTextObj.SetActive(true);
		if((highScore < score) || (highScore == null)){
			highScore = score;
			PlayerPrefs.SetFloat("highScore",highScore);
		}        
		Debug.Log("Congratulations + 現在のlevel"+level);     
	}
	
	public void setEnd (){
		this.end++;
		//Debug.LogError("えんｄ"+end);
	}
	
	public int getSentLevel(){
		return level;
	}
	
	public void reset(){
		conLevel = 0;
	}
	
}