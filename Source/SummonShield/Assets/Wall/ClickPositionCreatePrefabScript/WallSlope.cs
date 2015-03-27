using UnityEngine;
using System.Collections;

public class WallSlope : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
		LookAt2D(obj);
        SoundManager.Instance.PlaySE(2);
	}


	public GameObject obj;//playerを指定
	
	void Update() {
		

		//Move(obj);


		
	}

	void LookAt2D(GameObject Wall) {
		// 指定オブジェクトと回転させるオブジェクトの位置の差分(ベクトル)
		Vector3 pos = target.transform.position - transform.position;
		// ベクトルのX,Yを使い回転角を求める
		float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		Quaternion rotation = new Quaternion();
		// 回転角は右方向が0度なので-90
		rotation.eulerAngles = new Vector3(0, 0, angle + 90);
		// 回転
		transform.rotation = rotation;
	}

}
