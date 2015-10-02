/*
 * 破壊されないlazerエネミークラス
 */
using UnityEngine;
using System.Collections;

public class lazerEnemy : MonoBehaviour
{

    public Rigidbody rigid;
    public float deathTime = 5;

    private float fSpeed = 40f;

    void Start()
    {
        Destroy(this.gameObject, deathTime);
    }
    void FixedUpdate()
    {
        rigid.AddForce(Vector3.back * fSpeed);
    }

    public float statsSpeed
    {
        set
        {
            fSpeed = value;
        }
        get
        {
            return fSpeed;
        }
    }
}
