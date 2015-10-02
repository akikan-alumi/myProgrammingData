/*
 * プレイヤの両側からスターエネミーが生成されるクラス
 */
using UnityEngine;
using System.Collections;

public class spawnStarEnemy : spawnSmallStarEnemy
{

    public GameObject rotateObj2;
    public int myEnemyValue = 10;

    void Awake()
    {
        statsEnemyValue = myEnemyValue;
    }

    private IEnumerator instant()
    {
        for(int i = 0; i < enemyValue; i++)
        {
            if(i % 2 == 0)
            {
                Instantiate(rotateObj1, vec, player.transform.rotation);
            }
            else
            {
                Instantiate(rotateObj2, vec, player.transform.rotation);
            }

            print("コルーチンでインスタンス生成");
            yield return new WaitForSeconds(instTime);
        }
        Destroy(this.gameObject);
    }
}
