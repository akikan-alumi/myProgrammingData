using UnityEngine;
using System.Collections;

/// <summary>
/// 根本から派生している回路
/// </summary>
public class CircuitChild : CircuitParent 
{
	//親のゲームオブジェクト
	//private GameObject parent;

	//一階層上のオブジェクトのSpriteRendererコンポーネント
	private SpriteRenderer parentSpRenderer;

	//スクリプト読み込み時に１度だけ処理
	void Awake() 
	{
		//親オブジェクトを取得
		//parent = transform.parent.gameObject;

		//このオブジェクトのSpriteRendererを取得
		spRenderer = GetComponent<SpriteRenderer> ();

		//一階層上のオブジェクトのSpriteRendererコンポーネントを取得
		parentSpRenderer = transform.parent.GetComponent<SpriteRenderer>();

		//この回路オブジェクトより下の階層にある全てのSpriteRendererコンポーネントを取得
		//childSpRenderer = GetComponentsInChildren <SpriteRenderer>();
	}

	//毎フレーム実行
	void Update()
	{
		FadeIn ();
		UpdateSpriteAlpha (alpha);
		UpdateSpriteAlpha ();
	}

	/// <summary>
	/// 親のα値以下にする
	/// </summary>
	private void UpdateSpriteAlpha()
	{
		if(this.spRenderer.color.a > parentSpRenderer.color.a){
			this.spRenderer.color = parentSpRenderer.color;
		}
	}
}
