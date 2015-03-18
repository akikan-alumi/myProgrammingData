using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public GameObject prefab;
    private int spawnTime;
    private int spawnTiming;
    public float moveSpeed = 2f;
    public float moveRange = 5f;
    private Vector2 here;
	// Use this for initialization
	void Start () {
        spawnTime = 0;
        spawnTiming = Random.Range(0,60);
        here = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        moveMethod();
        spawnMethod();
	}

    //spawnTimeをつねに加算し、ランダム時間ごとにインスタンス生成を行う。
    private void spawnMethod() {
        spawnTime++;
        if (spawnTime >= spawnTiming) {
            Instantiate(prefab,new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,0),Quaternion.identity);
            spawnTime = 0;
            spawnTiming = Random.Range(120,240);
        }
    }

    //sin波を使って移動するメソッド
    private void moveMethod() {
        var offs = new Vector2(0, Mathf.Sin(Time.time*moveSpeed)+here.y);
        transform.localPosition = new Vector2(transform.localPosition.x,offs.y*moveRange);
    }
}
