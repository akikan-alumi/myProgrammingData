using UnityEngine;
using System.Collections;

public class ClickPositionCreatePrefabScript : MonoBehaviour {
	// 生成したいPrefab
	public GameObject Prefab;
    public GameObject PrefabEf;
	private int stopFlg = 0; 

	[SerializeField]
	private int spawnMax = 5;

	public int SpawnMax{
		get{return spawnMax;}
	}

	/// <summary>
	/// ステージにいるwallの数を記録する
	/// </summary>
	public GameObject[] targets;

	// クリックした位置座標
	private Vector3 clickPosition;
	// Use this for initialization
	//float time = 0.0f;
	void Start () {
		targets = GameObject.FindGameObjectsWithTag("Wall");
		//Debug.Log (Prefab);

	}
	
	// Update is called once per frame
	void Update () {
		targets = GameObject.FindGameObjectsWithTag("Wall");

        if (Input.GetMouseButtonDown(0)) {
            // マウス入力で左クリックをした瞬間
            //if (Input.GetMouseButtonDown(0)) {
            // ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
            // Vector3でマウスがクリックした位置座標を取得する
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Z軸修正
            clickPosition.z = 0f;
            // オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
            // ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
            if (Time.timeScale != 0) {
                Instantiate(PrefabEf, clickPosition, PrefabEf.transform.rotation);//エフェクト
            }
            if ((targets.Length < spawnMax) && (stopFlg == 0)) {
                Instantiate(Prefab, clickPosition, Prefab.transform.rotation);//オブジェクト
            }

        }
	}


	public int sentFlg{
		get{return stopFlg;}
		set{ stopFlg = value;}
	}

}