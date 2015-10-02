/*
 * 壁エネミーの管理クラス
 */
using UnityEngine;
using System.Collections;

public class wallEnemy : smallFish
{

    public int myScore = 250;
    public int myHP = 50;
    public float mySpeed = 250f;

    void Start()
    {
        statsScore = myScore;
        statsHP = myHP;
        statsSpeed = mySpeed;
    }

}
