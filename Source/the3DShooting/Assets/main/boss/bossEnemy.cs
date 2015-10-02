/*
 * ボスエネミーの管理クラス
 */
using UnityEngine;
using System.Collections;

public class bossEnemy : smallFish
{
    public int myScore = 2000;
    public int myHP = 120;
    public GameObject[] theBoss;
    private playerLife pLife;

    void Start()
    {
        statsScore = myScore;
        statsHP = myHP;
        pLife = GameObject.FindWithTag("UI").GetComponent<playerLife>();
    }

    void FixedUpdate()
    {
        killMySelf();
    }

    private void killMySelf()
    {
        if(statsHP <= 0)
        {
            playerLife.Score += statsScore;
            for(int i = 0; i < theBoss.Length; i++)
            {
                Destroy(theBoss[i]);
                print("ボスDestroy");
            }
            pLife.statsGameClear = true;
        }
    }

}
