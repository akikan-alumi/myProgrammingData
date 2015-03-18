using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

    private float Speed;
	// Use this for initialization
	void Start () {
        Speed = -0.02f;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.rigidbody2D.AddForce(Vector2.right * -10f);
        //キネマ入れていると動かない
        transform.Translate(Vector3.right * Speed);
	}
}
