/*
 * スターエネミーの管理クラス
 */
using UnityEngine;
using System.Collections;

public class starEnemy : smallFish
{
    public GameObject gameObj;
    public GameObject deathInstObj;
    public int myScore = 50;

    [SerializeField]
    private int myHP = 1;
    private float fRnd;
    private Quaternion quat = Quaternion.AngleAxis(90, Vector3.left);
    private GameObject parent;
    void Start()
    {
        parent = this.transform.parent.gameObject;
        statsHP = myHP;
        statsScore = myScore;
        fRnd = Random.Range(1.5f, 3.5f);
        StartCoroutine("shoot");
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
            print("星：HP0");
            Instantiate(deathInstObj, this.gameObject.transform.position, quat);
            print("エネミー発射");
            Destroy(parent.gameObject);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator shoot()
    {

        yield return new WaitForSeconds(fRnd);
        Instantiate(gameObj, this.gameObject.transform.position, quat);
    }
}
