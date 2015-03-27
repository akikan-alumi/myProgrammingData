using UnityEngine;
using System.Collections;

public class Efect : MonoBehaviour {

	[SerializeField]
	private GameObject unrock;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag ("Enemy")) {
			Instantiate (unrock, transform.position, transform.rotation);
            SoundManager.Instance.PlaySE(1);
	    }
	}


}
