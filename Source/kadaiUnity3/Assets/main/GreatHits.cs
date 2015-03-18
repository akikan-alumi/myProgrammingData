using UnityEngine;
using System.Collections;

public class GreatHits : MonoBehaviour {
	public bool isMouseOver;
	public counter cnt;
	public bool hits=false;

	private Vector3 go;
	// Use this for initialization
	void Start () {
		go = this.gameObject.transform.position;
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
				SoundManager.Instance.PlaySE(3);
				cnt.setScore(2);
				this.hits = true;
			}
		}
		/**
		 *  的にあたったら
		 * ここでランダム関数を使って別のところに移動させる
		 */
		if(hits){
			float scrX = moveRandom(Screen.width/10);
			float scrY = moveRandom(Screen.height/10);

			this.transform.position = new Vector2(scrX - Screen.width/20,scrY- Screen.height/20);

			hits=false;
		}
		isMouseOver= false;
	}
	void OnMouseOver()
	{
		isMouseOver= true;
	}		

	private float moveRandom(float scr){
		float pos = Random.Range(0f,scr);

		return pos;
	}

	public void zeroPos(){
		this.transform.position = go;
	}

}
