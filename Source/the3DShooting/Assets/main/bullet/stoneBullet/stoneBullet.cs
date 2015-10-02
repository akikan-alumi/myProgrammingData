/*
 * 石弾のクラス
 */
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class stoneBullet : bullet
{
    [SerializeField]
    private float mySpeed = 10f;
    [SerializeField]
    private int myDamage = 5;


    void Awake()
    {
        Speed = mySpeed;
        Damage = myDamage;
    }

}
