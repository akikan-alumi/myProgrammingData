using UnityEngine;
using System.Collections;

public class Revolution : MonoBehaviour {
	[SerializeField]
	private int speed = 10;
    [SerializeField]
	private float changeTime = 0f;
    [SerializeField]
	private float changeNum = 0f;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		changeTime += Time.deltaTime;
		changeNum = Random.Range (5f, 11f);
		
		//一定時間で回転方向変化
		if(changeTime >= changeNum){
			speed *= -1;
			changeTime = 0f;
		}

		rigidbody2D.velocity = transform.right.normalized * speed;
	}

	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("riverce")) { // 画面下で反転
			speed *= -1;
			Debug.Log("SpawnerHit");
		}
	}


}
