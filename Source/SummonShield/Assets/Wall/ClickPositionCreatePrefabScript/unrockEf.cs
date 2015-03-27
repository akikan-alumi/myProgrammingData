using UnityEngine;
using System.Collections;

public class unrockEf : MonoBehaviour {

    void OnAnimationFinish() {
		Destroy (gameObject);
	}
    void Start() {
        Destroy(gameObject, 0.5f);
    }

}
