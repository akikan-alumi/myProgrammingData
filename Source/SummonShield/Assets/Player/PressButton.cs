using UnityEngine;
using System.Collections;

/// <summary>
/// ボタンが押されたときの処理
/// </summary>
public class PressButton : MonoBehaviour {
	private ClickPositionCreatePrefabScript stopFlg;
	[SerializeField]
	private GameObject ClickObj;
	/// <summary>
	/// 一時停止時に表示するCanvasを設定
	/// </summary>
	[SerializeField]
	private GameObject stopMenu;
	[SerializeField]
	private GameObject resultObj;
	private Result rs;
	
	void Start(){
		rs = resultObj.GetComponent<Result> ();
		stopFlg = ClickObj.GetComponent<ClickPositionCreatePrefabScript> ();
	}
	
	/// <summary>
	/// タイトル画面で,画面をタップする
	/// </summary>
	public void TapScreen(){
		Time.timeScale = 1;
		Debug.Log ("Tap Screen");
	}
	
	/// <summary>
	/// ボタンが押されたら一時停止するメソッド
	/// </summary>
	public void PressButtonStop(){
		if (Time.timeScale != 0) {
			stopFlg.sentFlg = 1;
			Time.timeScale = 0;
			stopMenu.SetActive(true);
			Debug.Log("Stop!");
			SoundManager.Instance.PlaySE(0);
		} else {
			stopFlg.sentFlg = 0;
			Time.timeScale = 1;
			stopMenu.SetActive(false);
			Debug.Log("Start!");
			SoundManager.Instance.PlaySE(0);
		}
	}
	
	/// <summary>
	/// TitleButtonが押されたらTITLESceneに移動する
	/// </summary>
	public void PressButtonTitle(){
		rs.reset ();
		SoundManager.Instance.StopBGM();
		Debug.Log ("Press Button Title");
		SoundManager.Instance.PlaySE(0);
		Application.LoadLevel("titleScene");
	}
	
	/// <summary>
	/// RetryButtonが押されたらScene再読み込み
	/// </summary>
	public void PressButtonRetry(){
		rs.reset ();
		SoundManager.Instance.StopBGM();
		Debug.Log ("Press Button Retry");
		SoundManager.Instance.PlaySE(0);
		stopFlg.sentFlg = 0;
		Time.timeScale = 1;
		Application.LoadLevel("normalMode");
	}
	
	public void PressButtonContinue(){
		SoundManager.Instance.StopBGM ();
		Debug.Log ("Press Button Retry");
		SoundManager.Instance.PlaySE (0);
		stopFlg.sentFlg = 0;
		Time.timeScale = 1;
		Application.LoadLevel ("normalMode");
	}
}