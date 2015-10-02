/*
 * 壁エネミー自体の回転速度クラス
 */
using UnityEngine;
using System.Collections;

public class wallRotate : MonoBehaviour
{

    public GameObject gameobj;

    private float speed;

    void Start()
    {
        speed = Random.Range(150f, 250f);
    }

    void Update()
    {
        gameobj.transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
