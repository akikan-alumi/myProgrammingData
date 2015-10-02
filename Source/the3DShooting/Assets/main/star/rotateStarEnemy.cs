/*
 * スターエネミーが回るようにするためのクラス
 */
using UnityEngine;
using System.Collections;

public class rotateStarEnemy : rotateRootEnemy
{

    public bool rebirthRotate = false;
    public bool rebirthMove = false;
    public Rigidbody rigid;

    private float moveSpeed;

    void Awake()
    {
        if(rebirthMove)
        {
            moveSpeed = -10;
        }
        else
        {
            moveSpeed = 10;
        }
        speed = 250;
        myDeathTime = 15f;
        if(rebirthRotate)
        {
            vec = Vector3.back;
        }
    }

    void FixedUpdate()
    {
        rotateObj();
        move();
    }

    void move()
    {
        gameObject.transform.Translate(0, 0, moveSpeed * Time.fixedDeltaTime);
    }

    public bool rebirthCheck
    {
        set
        {
            rebirthRotate = true;
        }
        get
        {
            return rebirthRotate;
        }
    }
}
