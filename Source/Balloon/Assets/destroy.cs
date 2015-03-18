using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	// Use this for initialization

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
