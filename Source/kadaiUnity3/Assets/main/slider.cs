using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class slider : MonoBehaviour
{
	public ChangeCamera cc;
	public void UpdateSElevel (float value)
	{
		Text lbl = GetComponent<Text>();
		if (lbl != null && cc.startCamera.enabled){
			lbl.text = Mathf.RoundToInt (value * 100) + "%";
			SoundManager.Instance.volume.SE = value;
		}
	}
	
	public void UpdateBGMlevel (float value)
	{
		Text lbl = GetComponent<Text>();
		if (lbl != null && cc.startCamera.enabled){
			lbl.text = Mathf.RoundToInt (value * 100) + "%";
			SoundManager.Instance.volume.BGM = value;
		}
	}
	public void checkSE(){
		if(cc.startCamera.enabled){
			SoundManager.Instance.StopSE();
			SoundManager.Instance.PlaySE(1);
		}
	}

	public void checkBGM(){
		if(cc.startCamera.enabled){
			SoundManager.Instance.StopBGM();
			SoundManager.Instance.PlayBGM(1);
		}
	}
}