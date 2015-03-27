using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v;
		v.x = 0;
		v.y = 0;
		rigidbody2D.velocity = v;
	}
}
