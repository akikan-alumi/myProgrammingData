/*
 * 触ったオブジェクトを消し去る
 */
using UnityEngine;
using System.Collections;

public class destroyMethod : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
