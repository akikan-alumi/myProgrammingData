using UnityEngine;
using System.Collections;

/// <summary>
/// 回路の親、根本
/// </summary>
public class CircuitParent : MonoBehaviour 
{
	//このオブジェクトのSpriteRenderer
	protected SpriteRenderer spRenderer;

	//この回路オブジェクトより下の階層にある全ての回路画像
	protected SpriteRenderer[] childSpRenderer;

	//画像のα値
	protected float alpha = 1;

	//回路画像がフェードインする速度
	protected float fadeInSpeed = 4.0f;

	//回路画像がフェードアウトする速度
	protected float fadeOutSpeed = 10.0f;

	//スクリプト読み込み時に一度だけ実行
	void Awake() 
	{
		//このオブジェクトのSpriteRendererを取得
		spRenderer = GetComponent<SpriteRenderer> ();

		//この回路オブジェクトより下の階層にある全てのSpriteRendererコンポーネントを取得
		childSpRenderer = GetComponentsInChildren <SpriteRenderer>();
	}

	//毎フレーム処理
	void Update()
	{
		FadeIn ();
		UpdateSpriteAlpha (alpha);
	}

	/// <summary>
	/// 回路をフェードインさせる
	/// </summary>
	protected void FadeIn()
	{
		alpha += Time.deltaTime * fadeInSpeed;

		if(alpha >= 1)alpha = 1;
	}

	/// <summary>
	/// 回路画像の透過度を更新する
	/// </summary>
	/// <param name="alpha">透過度</param>
	protected void UpdateSpriteAlpha (float alpha) 
	{
		//回路を徐々に透過する
		this.spRenderer.color = new Color(1, 1, 1, alpha);
	}

	/// <summary>
	/// エネミーと接触している間、回路画像を徐々に透過させていく
	/// </summary>
	/// <param name="col">Collider2D</param>
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Enemy"))
		{
			//α値を徐々に下げる
			alpha -= Time.deltaTime * fadeOutSpeed;

			if(alpha < 0)alpha = 0;
		}
	}
}
