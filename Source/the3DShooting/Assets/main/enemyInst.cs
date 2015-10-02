/*
 * エネミーの生成を統括するクラス
 */
using UnityEngine;
using System.Collections;

[System.Serializable]
public class enemyInstData
{
    public GameObject[] gameObject;
    public float[] fTime;
}

[System.Serializable]
public class enemyInst : MonoBehaviour
{
    public enemyInstData instData;

    [SerializeField]
    private int wave = 0;
    [SerializeField]
    private float fTime = 0;

    void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {
        fTime += Time.deltaTime;
        if(fTime > instData.fTime[wave] && instData.gameObject[wave] != null)
        {
            fTime = 0;
            Instantiate(instData.gameObject[wave], this.transform.position, this.transform.rotation);
            wave++;

        }
    }
}
