using UnityEngine;
using System.Collections;

/// <summary>
/// タイトル画面でシールドを自動生成するスクリプト
/// </summary>
public class TitleWallSpawner : MonoBehaviour {
    
    //Playerと自動生成するWallとタップ時のエフェクト
    [SerializeField]
    private GameObject player,wall,tapEffect;

    //Wallが生成される座標
    private Vector3 spawnPoint;

	/// <summary>
	/// エネミーとCollider2D(Trigger)が衝突したらその中間に盾を生成する
	/// </summary>
	/// <param name="collision">Collision.</param>
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {

            //Wallを生成する座標を計算する
            spawnPoint = (collision.gameObject.transform.position - player.transform.position)/2;

            //Wallを自動生成
            Instantiate(wall,spawnPoint,transform.rotation);

			//Tapエフェクトを生成
			Instantiate(tapEffect,spawnPoint,transform.rotation);
            
        }
    }
}
