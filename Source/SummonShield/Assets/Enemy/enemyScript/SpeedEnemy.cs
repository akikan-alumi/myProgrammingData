using UnityEngine;
using System.Collections;

public class SpeedEnemy : MonoBehaviour {

    [SerializeField]
    private int Hp = 1;
	public GameObject bossEnemy;

	void Start(){
        if (GameObject.Find("BossEnemy1(Clone)") != null) {
            Debug.Log("ボスがいたので消えます");
			Destroy(this.gameObject);
		}
	}

    public void setHP() {
        Hp--;
        if (Hp < 1) {
            Destroy(this.gameObject);
            Debug.Log("PlayerHit");

        }

    }
}
