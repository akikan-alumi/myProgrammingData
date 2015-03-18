using UnityEngine;
using System.Collections;

public class GoodHits : MonoBehaviour {
	public bool isMouseOver;
	public counter cnt;
	public GreatHits gh;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Mouse0) && isMouseOver)
		{
			//ボタンが押された画像に切り替え
			if(Input.GetKeyDown (KeyCode.Mouse0))
			{
				//押された瞬間だけ実行したい処理
				SoundManager.Instance.StopSE();
				SoundManager.Instance.PlaySE(2);
				cnt.setScore(1);
				gh.hits = true;
			}
		}

		isMouseOver= false;
	}
	void OnMouseOver()
	{
		isMouseOver= true;
	}
	//計算抜きで自分のメッシュの上でクリックされたか調べられる 
	
	
	
}
