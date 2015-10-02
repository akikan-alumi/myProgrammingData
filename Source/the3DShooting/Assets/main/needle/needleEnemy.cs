/*
 * 破壊されないneedleエネミー
 */
using UnityEngine;
using System.Collections;

public class needleEnemy : lazerEnemy
{
    public float mySpeed;
    private float rotateSpeed;

    void Awake()
    {
        rotateSpeed = 360f;
        statsSpeed = mySpeed;
    }

    void FixedUpdate()
    {
        rigid.velocity = Vector3.back * statsSpeed;
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
