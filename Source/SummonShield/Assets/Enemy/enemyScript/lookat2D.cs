using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class lookat2D : MonoBehaviour {
    [SerializeField]
	private float speed;
	public float[] speedLevel = {1.0f,1.1f,1.2f,1.3f,1.4f,1.5f,1.6f,1.6f};
	private int level = 0;
	//playerを指定
	[SerializeField]
	private GameObject obj;
	public GameObject ResultObj;
	private Result result;

	void Start(){
        if (GameObject.Find("Result")) {
            ResultObj = GameObject.Find("Result").gameObject;
            result = ResultObj.GetComponent<Result>();
            level = result.getSentLevel();
            speed = speedLevel[level];
        }
	}

	//public CircuitChild  cChild;
	//public CircuitParent cParent;
	
	//private GameObject circuit
    void Update() {
		
		LookAt2D (obj);
    }

	void FixedUpdate(){
		Move (obj);
	}

    void Move(GameObject target) {
        // (target.transform.position - transform.position)だけでは
        // 距離によって移動速度が変わる
        //よってnormalizedで一定速度にする
        rigidbody2D.velocity = (target.transform.position - transform.position).normalized * speed;
    }

    void LookAt2D(GameObject target) {
        // 指定オブジェクトと回転させるオブジェクトの位置の差分(ベクトル)
        Vector3 pos = target.transform.position - transform.position;
        // ベクトルのX,Yを使い回転角を求める
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        // 回転角は右方向が0度なので-90
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        // 回転
        transform.rotation = rotation;
    }
    public void setSpeed() {
        speed = 0;
    }

}