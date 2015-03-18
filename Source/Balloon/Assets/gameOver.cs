using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class gameOver : MonoBehaviour {
    public Text text;
    public bool game = true;
	// Use this for initialization
	void Start () {
        game = true;
        //text = GameObject.Find("Text").GetComponent();
	}
	
	// Update is called once per frame
	void Update () {

        if (!game) {
            text.text = "GameOver";
        }
        else {
            text.text = "";
        }
	}
}
