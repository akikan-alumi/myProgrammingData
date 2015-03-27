using UnityEngine;
using System.Collections;

public class RandomStart : MonoBehaviour {
	private float rndStart;
	private float changeTime = 0f;
	private float changeNum = 0f;

	// スタート位置を変更
	void Start () {
		rndStart = Random.Range (0f, 1200f);
		rndPosition ();
	}
	
	// 一定の間隔でワープ
	void Update () {
		rndStart = Random.Range (0f, 3000f);
		changeTime += Time.deltaTime;
		changeNum = Random.Range (3f, 5f);
		if(changeTime >= changeNum){
			rndPosition();
			changeTime = 0f;
		}
	}
	void rndPosition(){
		if ((rndStart >= 0f && rndStart <= 99f) || (rndStart >= 1600f && rndStart <= 1699f)) {
				transform.localPosition = new Vector3 (12.7f, 12.7f, 0f);
		} else if ((rndStart >= 100f && rndStart <= 199f) || (rndStart >= 1700f && rndStart <= 1799f)) {
				transform.localPosition = new Vector3 (12.0f, 1.7f, 0f);
		} else if ((rndStart >= 200f && rndStart <= 299f) || (rndStart <= 1800f && rndStart <= 1899f)) {
				transform.localPosition = new Vector3 (-12.0f, 1.7f, 0f);
		} else if ((rndStart >= 300f && rndStart <= 399f) || (rndStart <= 1900f && rndStart <= 1999f)) {
				transform.localPosition = new Vector3 (-2.2f, 12.6f, 0f);
		} else if ((rndStart >= 400f && rndStart <= 499f) || (rndStart <= 2900f && rndStart <= 2099f)) {
				transform.localPosition = new Vector3 (2.2f, 12.6f, 0f);
		} else if ((rndStart >= 500f && rndStart <= 599f) || (rndStart <= 2100f && rndStart <= 2199f)) {
				transform.localPosition = new Vector3 (12.0f, 4.1f, 0f);
		} else if ((rndStart >= 600f && rndStart <= 699f) || (rndStart <= 2200f && rndStart <= 2299f)) {
				transform.localPosition = new Vector3 (-12.0f, 4.1f, 0f);
		} else if ((rndStart >= 700f && rndStart <= 799f) || (rndStart <= 2300f && rndStart <= 2399f)) {
				transform.localPosition = new Vector3 (4.5f, 11.9f, 0f);
		} else if ((rndStart >= 800f && rndStart <= 899f) || (rndStart <= 2400f && rndStart <= 2499f)) {
				transform.localPosition = new Vector3 (-4.5f, 11.9f, 0f);
		} else if ((rndStart >= 900f && rndStart <= 999f) || (rndStart <= 2500f && rndStart <= 2599f)) {
				transform.localPosition = new Vector3 (6.8f, 10.7f, 0f);
		} else if ((rndStart >= 1000f && rndStart <= 1099f) || (rndStart <= 2600f && rndStart <= 2699f)) {
				transform.localPosition = new Vector3 (-6.8f, 10.7f, 0f);
		} else if ((rndStart >= 1100f && rndStart <= 1199f) || (rndStart <= 2700f && rndStart <= 2799f)) {
				transform.localPosition = new Vector3 (10.7f, 7.0f, 0f);
		} else if ((rndStart >= 1200f && rndStart <= 1299f) || (rndStart <= 2800f && rndStart <= 2899f)) {
				transform.localPosition = new Vector3 (-10.7f, 7.0f, 0f);
		} else if ((rndStart >= 1300f && rndStart <= 1399f) || (rndStart <= 2900f && rndStart <= 2999f)) {
				transform.localPosition = new Vector3 (8.9f, 9.1f, 0f);
		} else {
				transform.localPosition = new Vector3 (-8.9f, 9.1f, 0f);
		}
	}
}