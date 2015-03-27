using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour {
    [SerializeField]
    private float rnd; 
	// Use this for initialization
	void Start () {
        rnd = Random.Range(45.0f,360.0f);
	}
	

	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,Time.deltaTime*rnd);
	}
}
