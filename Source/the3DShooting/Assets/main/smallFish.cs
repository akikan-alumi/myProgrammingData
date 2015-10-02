/*
 * 敵クラスのスーパクラス
 */
using UnityEngine;
using System.Collections;

public class smallFish : MonoBehaviour
{

    public Rigidbody rigid;

    private int score = 100;
    private int HP = 10;
    private float fSpeed = 500f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        moveThis();
        killMySelf();
    }

    protected void killMySelf()
    {
        if(HP <= 0)
        {
            playerLife.Score += statsScore;
            Destroy(this.gameObject);
        }
    }

    protected void moveThis()
    {
        this.rigid.velocity = new Vector3(0, 0, -fSpeed * Time.fixedDeltaTime);

    }


    public float statsSpeed
    {
        set
        {
            this.fSpeed = value;
        }
        get
        {
            return this.fSpeed;
        }
    }

    public int statsHP
    {
        set
        {
            this.HP = value;
        }
        get
        {
            return this.HP;
        }
    }

    public int statsScore
    {
        set
        {
            score = value;
        }
        get
        {
            return score;
        }
    }

}
