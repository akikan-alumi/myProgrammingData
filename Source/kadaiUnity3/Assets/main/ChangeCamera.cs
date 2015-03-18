using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {
	public Camera mainCamera;
	public Camera startCamera;
	public Camera endCamera;
	public bool switches=true;
	// Use this for initialization
	void Start () {
		mainCamera.enabled = false;
		startCamera.enabled = true;
		endCamera.enabled=false;
	}
	
	// Update is called once per frame
	public void playingStart(){
		if(switches){
		SoundManager.Instance.StopBGM();
		mainCamera.enabled = true;
		startCamera.enabled = false;
		endCamera.enabled = false;
			switches=!switches;
		}
	}

	public void resultGame(){
		mainCamera.enabled = false;
		startCamera.enabled = false;
		endCamera.enabled = true;
	}
	public void switching(){
		switches=true;
	}
}
