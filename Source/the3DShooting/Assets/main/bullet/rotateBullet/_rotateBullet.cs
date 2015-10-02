/*
 * 3wayバレットクラス
 */
using UnityEngine;
using System.Collections;

public class _rotateBullet : bullet
{

    public bool rebirth;

    private float fRotate = 720f;
    private float mySpeed = 40f;
    private int myDamage = 1;
    private Vector3 vec = Vector3.forward;

    void Awake()
    {
        Damage = myDamage;
        Speed = mySpeed;
        if(rebirth)
        {
            vec = Vector3.back;
        }
    }


    void FixedUpdate()
    {
        move();
        rotateObj();
    }

    void rotateObj()
    {
        this.gameObject.transform.RotateAround(Vector3.zero, vec, fRotate * Time.fixedDeltaTime);
    }
}
