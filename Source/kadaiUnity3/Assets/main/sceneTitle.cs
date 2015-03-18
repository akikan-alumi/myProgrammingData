using UnityEngine;
using System.Collections;


public class sceneTitle : MonoBehaviour {
	public Timer tm;
	// Use this for initialization
	public void scenes(){
		if(tm.myTimer<0){
		Application.LoadLevel(0);
		}
	}
}
