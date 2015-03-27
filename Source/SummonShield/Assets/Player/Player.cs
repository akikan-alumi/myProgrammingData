using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private GameObject result;
	private Result finish;

	// 初期化
	void Start () {
		finish = result.GetComponent<Result>();
	}

	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("Enemy")) { // Enemyに当たったらゲームオーバーをTrueに
            SoundManager.Instance.StopBGM();
            SoundManager.Instance.PlaySE(4);
			//Destroy(col.gameObject);
			finish.GameOver();
		}
	}
}
