/*
 * ゲームオーバー処理（ボツ）
 */
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
    private bool gameOver = false;

    void Start()
    {
        gameOver = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Enemy" || collider.tag == "Bullet")
        {
            gameOver = true;
            print("ゲームオーバー");
        }
    }
}
