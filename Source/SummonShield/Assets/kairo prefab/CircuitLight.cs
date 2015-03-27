using UnityEngine;
using System.Collections;

/// <summary>
/// 回路の青い光
/// </summary>
public class CircuitLight : MonoBehaviour 
{
	//SpriteRenderer
	private SpriteRenderer spRenderer;

	//青い光の発光元の回路を取得
	private SpriteRenderer parentSpRenderer;

	//スクリプト読み込み時に一度だけ処理
	void Awake()
	{
		//このゲームオブジェクトのSpriteRendererコンポーネントを取得
		spRenderer = GetComponent<SpriteRenderer> ();

		//発光元回路のSpriteRendererを取得
		parentSpRenderer = transform.parent.GetComponent<SpriteRenderer> ();
	}
	
	//毎フレーム処理
	void Update () 
	{
		UpdateSpriteAlpha();
	}

	/// <summary>
	/// 発光元回路と同じ透過度に更新する
	/// </summary>
	private void UpdateSpriteAlpha()
	{
		this.spRenderer.color = parentSpRenderer.color;
	}
}
