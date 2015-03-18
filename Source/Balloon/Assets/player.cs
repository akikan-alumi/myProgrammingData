using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    private float Speed = -0.02f;
    public gameOver go;
    private bool game;
	// Use this for initialization
	void Start () {
        game = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")&&game) {
            this.rigidbody2D.AddForce(Vector2.up * 150f);
        }
        transform.Translate(Vector3.right * Speed);
	}
    void FixedUpdate() {
        //左右キーの入力
        if (game) {
            float h = Input.GetAxis("Horizontal");
            this.rigidbody2D.AddForce(Vector2.right * h * 5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("enemy")) {
            this.rigidbody2D.fixedAngle = false;
            this.collider2D.isTrigger = true;
            game = false;
            Destroy(this.gameObject,2f);
            //go = GetComponent<gameOver>();
            go.game = false;
        }
    }
}
