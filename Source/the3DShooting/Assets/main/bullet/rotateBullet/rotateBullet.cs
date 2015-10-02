/*3wayバレット生成クラス*/
using UnityEngine;
using System.Collections;

public class rotateBullet : bullet
{

    public GameObject RRotateBullet;
    public GameObject LRotateBullet;

    void Awake()
    {
        StartCoroutine("instRotateBullet");
    }

    IEnumerator instRotateBullet()
    {
        Instantiate(RRotateBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
        yield return null;
        Instantiate(LRotateBullet, this.gameObject.transform.position, this.gameObject.transform.rotation);
        yield return null;
    }
}
