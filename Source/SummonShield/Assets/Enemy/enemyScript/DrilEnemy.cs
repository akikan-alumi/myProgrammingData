using UnityEngine;
using System.Collections;

public class DrilEnemy : MonoBehaviour {
    [SerializeField]
    private int Hp = 2;

    public GameObject enemySield;

	void Start(){
        if (GameObject.Find("BossEnemy1(Clone)")) {
			Destroy(this.gameObject);
			        }
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("Wall")) {

			
		}
	}

    public void setHP() {
        Hp--;
        if (Hp < 1) {
            Destroy(this.gameObject);
            Debug.Log("PlayerHit");

        } else if (Hp == 1) {
            foreach (Transform t in this.transform) {
                Destroy(t.gameObject);
            }
        }
    }

}
