using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour {
	public GameObject CreditText;
    public GameObject NormalModeButton;
	bool TriggerSwitch = false;

	/// <summary>
	/// クレジットボタンをタップした時
	/// </summary>
	public void TapCredit() 
	{
		//Debug.Log ("clicked");
		if(TriggerSwitch == false){
			//Trigger ON 
			CreditText.SetActive(true); 
			TriggerSwitch = true;
			Debug.Log ("ON");
            SoundManager.Instance.PlaySE(0);
            //クレジット開いたまま別シーンに移動させないコード
            NormalModeButton.SetActive(false);
		}else if(TriggerSwitch == true){
			// Trigger OFF 
			CreditText.SetActive(false); 
			TriggerSwitch = false;
			Debug.Log ("OFF");
            SoundManager.Instance.PlaySE(0);
            //クレジット閉じていたら別シーンに移動させることが出来るコード
            NormalModeButton.SetActive(true);
		}
	}

	/// <summary>
	/// ノーマルボタンをタップした時
	/// </summary>
	public void TapNormal()
	{
        SoundManager.Instance.PlaySE(0);
		//シーン遷移
		Time.timeScale = 1;
        Application.LoadLevel(1);
		Debug.Log ("TapNormalButton");
	}

	/// <summary>
	/// ハードボタンをタップした時
	/// </summary>
	public void TapHard()
	{
		//シーン遷移
        Application.LoadLevel(2);
		Debug.Log ("TapHardButton");
	}

	/// <summary>
	/// ヘルボタンをタップした時
	/// </summary>
	public void TapHell()
	{
		//シーン遷移
        Application.LoadLevel(3);
		Debug.Log ("TapHellButton");
	}
}