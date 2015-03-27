using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleHiScore : MonoBehaviour {
	private static float highScore;
	private Text scoreText;
    private Text HighScoreString;
	[SerializeField]
	private GameObject scoreTextObj;
    public GameObject highScoreTextObj;
	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetFloat ("highScore");
		scoreText = scoreTextObj.GetComponent<Text> ();
        HighScoreString = highScoreTextObj.GetComponent<Text>();
		if ((highScore == 0) || (highScore == null)){
			scoreText.text = "";
            HighScoreString.text = "";
		}else{		
			scoreText.text = "" + highScore.ToString("F0");
            HighScoreString.text = "HIGHSCORE";
		}
	}

}
