using UnityEngine;
using System.Collections;

public class HitDestroyWall : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Enemy")){
            Destroy(col.gameObject);
        }
    
    }
}
