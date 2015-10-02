/*
 弾の進行方向のクラス
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour
{
    public Rigidbody rigid;
    public float fDestroyTime = 1f;

    private float fSpeed = 50f;
    private int iDamage = 2;

    void Start()
    {
        Destroy(this.rigid.gameObject, fDestroyTime);
        this.tag = ("Bullet");
    }

    void FixedUpdate()
    {
        move();
    }

    protected void move()
    {
        this.rigid.transform.Translate(0, 0, fSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Enemy")
        {
            print("命中");
            smallFish s = collider.GetComponent<smallFish>();
            s.statsHP -= iDamage;
            Destroy(this.gameObject);
        }
    }

    public int Damage
    {
        set
        {
            iDamage = value;
        }
        get
        {
            return iDamage;
        }
    }

    public float Speed
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
