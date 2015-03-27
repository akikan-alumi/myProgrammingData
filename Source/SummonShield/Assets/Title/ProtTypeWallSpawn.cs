using UnityEngine;
using System.Collections;

public class ProtTypeWallSpawn : MonoBehaviour {
    
    //Playerと自動生成するWall
    public GameObject player,Wall;

    //Wallが生成される座標
    private Vector3 spawnPoint;
	
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {

            //Wallを生成する座標を計算する
            spawnPoint = (collision.gameObject.transform.position - player.transform.position)/2;

            //Wallを自動生成
            Instantiate(Wall,spawnPoint,transform.rotation);
           
        }
    }
}
