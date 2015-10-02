/*
 ルートオブジェクトを移動させることによって子のプレイヤーも楽に動かすためのクラス
 */

using UnityEngine;
using System.Collections;

public class rotateObj : MonoBehaviour
{
    public GameObject gameObj;
    public float rotateValue;

    void Start()
    {
        gameObj.transform.Rotate(Vector3.zero);
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        gameObj.transform.Rotate(0, 0, input * rotateValue * Time.deltaTime);
    }
}
