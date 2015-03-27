using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Destroy(this.gameObject,0.5f);
        if (Time.timeScale == 0) {
            Destroy(this.gameObject);
        }
	}
    void Update() {
        
    }
}
