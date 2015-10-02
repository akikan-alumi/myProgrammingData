/*
 プレイヤーが弾を打つクラス（ボツ）
 */
using UnityEngine;
using System.Collections;

public class normalShot : MonoBehaviour
{
    public GameObject bullet;

    private float interval = 0;
    private const float waitTime = 0.05f;
    private const float zValue = 1f;

    void Update()
    {
        this.shot();
    }

    private void shot()
    {
        interval += Time.deltaTime;
        if(Input.GetButton("Fire1") && interval >= waitTime)
        {
            interval = 0;
            Instantiate(this.bullet,
                new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + zValue),
                this.gameObject.transform.rotation);
        }
    }
}
