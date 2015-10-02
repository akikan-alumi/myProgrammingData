/*
 * 壁エネミーのルートオブジェクトクラス
 */
using UnityEngine;
using System.Collections;

public class rotateRootEnemy : MonoBehaviour
{

    protected float deathTime = 10f;
    protected Vector3 vec = Vector3.forward;
    protected float speed = 513f;

    void Start()
    {
        destroyObj();
    }

    void FixedUpdate()
    {
        rotateObj();
    }

    void destroyObj()
    {
        Destroy(this.gameObject, deathTime);
    }

    public void rotateObj()
    {
        gameObject.transform.Rotate(vec * Time.fixedDeltaTime * speed);
    }

    public float myDeathTime
    {
        set
        {
            this.deathTime = value;
        }
        get
        {
            return this.deathTime;
        }
    }
}
