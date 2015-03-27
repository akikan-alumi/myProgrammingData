using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// シールドをあと何枚生成できるか
/// </summary>
public class ShieldSpawnLimit : MonoBehaviour {

	/// <summary>
	/// シールド生成スクリプト
	/// </summary>
	private ClickPositionCreatePrefabScript CPCPS;

	/// <summary>
	/// 残シールド数を表示するテキスト
	/// </summary>
	[SerializeField]
	private Text shieldSpawnLimit;

	//現在生成されているWall
	private GameObject[] spawnedShields;

	/// <summary>
	/// シールド生成スクリプトにあるシールド展開数上限
	/// </summary>
	private int spawnMax;

	//スクリプト読み込み時に１度だけ処理
	void Awake()
	{
		//アタッチされているClickPositionCreatePrefabScript(CPCPS)を取得
		CPCPS = gameObject.GetComponent<ClickPositionCreatePrefabScript>();
	}

	// 初期化
	void Start () 
	{
		//シールド展開数上限を取得
		spawnMax = CPCPS.SpawnMax;

		//Debug.Log ("SpawnMax = " + spawnMax);

		//現在展開されているシールド
		spawnedShields = CPCPS.targets;
	}
	
	//毎フレーム処理
	void Update () 
	{
		UpdateSummonShields ();
	}

	/// <summary>
	/// 残シールド数を更新
	/// </summary>
	private void UpdateSummonShields()
	{
		spawnedShields = CPCPS.targets;
		int shields = (spawnMax - spawnedShields.Length);
		shieldSpawnLimit.text = shields.ToString();
	}
}
