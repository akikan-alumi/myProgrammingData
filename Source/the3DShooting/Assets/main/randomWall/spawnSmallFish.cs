/*
 * 一定時間ごとにエネミーを出現させるクラス
 */
using UnityEngine;
using System.Collections;

public class spawnSmallFish : MonoBehaviour
{
    public GameObject gameObj;
    private float spawnTime = 0;
    private float checkTime;

    void Start()
    {
        myTime();
    }

    void Update()
    {
        if(spawnTime > checkTime)
        {
            instantiateEnemy();
        }
        else
        {
            spawnTime += Time.deltaTime;
        }
    }

    void myTime()
    {
        float minA = 0.1f, minB = 1f, maxA = 1f, maxB = 3f;

        float A = Random.Range(minA, maxA);
        float B = Random.Range(minB, maxB);

        checkTime = Random.Range(A, B);

    }

    void instantiateEnemy()
    {
        Instantiate(gameObj, this.transform.position, this.transform.rotation);
        spawnTime = 0;
    }
}
