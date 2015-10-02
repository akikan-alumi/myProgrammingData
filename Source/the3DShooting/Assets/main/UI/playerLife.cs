/*
 * プレイヤーのスコアなどUI周りのクラス
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{

    public static int Score = 0;

    public GameObject player;
    public Canvas resultCanvas;
    public Canvas playerCanvas;
    public Text lifeText;
    public Text gameOverText;
    public Text scoreText;
    public Text topRightScoreText;

    private mainPlayer mPlay;
    private int slowUpScore = 0;
    private int updateScoreint = 7;
    private bool gameOverFlag = false;
    private bool gameClearFlag = false;

    void Start()
    {
        Score = 0;
        resultCanvas.enabled = false;
        playerCanvas.enabled = true;
        mPlay = player.GetComponent<mainPlayer>();
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        nowHP();
        gameScore();
        print("score:" + Score);
    }

    void nowHP()
    {
        lifeText.text = mPlay.statsPlayerHP + "";
    }

    void gameScore()
    {

        if(gameOverFlag)
        {
            gameOverText.text = "GAME OVER";
            playerCanvas.enabled = false;
            resultCanvas.enabled = true;
            Time.timeScale = 0;
        }
        else if(gameClearFlag)
        {
            gameOverText.text = "CONGRATULATIONS!";
            playerCanvas.enabled = false;
            resultCanvas.enabled = true;
            Time.timeScale = 0;
        }

        scoreText.text = "SCORE:" + Score;

        if(slowUpScore < Score)
        {
            slowUpScore += updateScoreint;
        }
        else if(slowUpScore > Score)
        {
            slowUpScore = Score;
        }

        topRightScoreText.text = "" + slowUpScore;
    }

    public bool statsGameOver
    {
        set
        {
            if(!gameClearFlag)
            {
                gameOverFlag = value;
                print("ゲームオーバー");
            }
        }
        get
        {
            return gameOverFlag;
        }
    }

    public bool statsGameClear
    {
        set
        {
            if(!gameOverFlag)
            {
                gameClearFlag = value;
                print("ゲームクリア");
            }
        }
        get
        {
            return gameClearFlag;
        }
    }
}
