using UnityEngine;
using System.Collections;

//赤。青回路の描画On/Off
public class CircuitSwitch : MonoBehaviour 
{
	//青回路
	[SerializeField]
	private GameObject blueCircuit;

	//赤回路
	[SerializeField]
	private GameObject redCircuit;

	/// <summary>
	/// 回路を青、赤と交互に切り替える
	/// </summary>
	public void CSwitch()
	{
		if (blueCircuit.activeSelf) 
		{
			Debug.Log("青回路をオフにして赤回路をオンにしました");
			blueCircuit.SetActive(false);
			redCircuit.SetActive(true);
		}else{
			Debug.Log("青回路をオンにして赤回路をオフにしました");
			redCircuit.SetActive(false);
			blueCircuit.SetActive(true);
		}
	}
}