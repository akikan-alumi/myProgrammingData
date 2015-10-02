/*
 * １列のスターエネミーが生成されるクラス
 */
using UnityEngine;
using System.Collections;

public class spawnSmallStarEnemy : MonoBehaviour
{

    public bool rebirthAttack = false;
    public GameObject rotateObj1;
    public int enemyValue = 5;

    protected GameObject player;
    protected float instTime = 0.05f;
    protected Vector3 vec = new Vector3(0, 0, -15);

    private Vector3 rebirthVec = new Vector3(0, 0, 50);

    void Start()
    {
        player = GameObject.FindWithTag("RootPlayer");
        if(rebirthAttack)
        {
            vec = rebirthVec;
        }
        StartCoroutine("instant");
    }

    private IEnumerator instant()
    {
        for(int i = 0; i < enemyValue; i++)
        {
            Instantiate(rotateObj1, vec, player.transform.rotation);
            print("コルーチンでインスタンス生成");
            yield return new WaitForSeconds(instTime);
        }
        Destroy(this.gameObject);
    }

    public Vector3 statsVec3
    {
        set
        {
            vec = value;
        }
        get
        {
            return vec;
        }
    }

    public int statsEnemyValue
    {
        set
        {
            enemyValue = value;
        }
        get
        {
            return enemyValue;
        }
    }
}
