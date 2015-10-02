/*
 * プレイヤーのHPや弾の管理のクラス
 */
using UnityEngine;
using System.Collections;

public class mainPlayer : MonoBehaviour
{
    public GameObject[] bullets;
    public float[] bulletInterval;
    public playerLife pLife;

    private Renderer rend;
    [SerializeField]
    private bool damageFlag = false;
    private Material myMaterial;
    private int flashTime = 1;
    private Animator animator;

    private int mouseWheelCheck;
    private float interval = 0;
    private float waitTime = 0.05f;
    private const float zValue = 1f;
    private int playerHP = 10;


    void Start()
    {
        rend = this.GetComponent<Renderer>();
        animator = this.GetComponent<Animator>();
        myMaterial = this.rend.material;
    }

    void Update()
    {
        shotBullet();
        Wheel();
        gameOverCheck();
        damageEffect();
    }

    void OnTriggerEnter(Collider collider)
    {
        if((collider.tag == "Enemy" || collider.tag == "Bullet") && !damageFlag)
        {
            statsPlayerHP -= 1;
            print("げんざいのHP：" + statsPlayerHP);

            damageFlag = true;
            StartCoroutine("damageCoroutine");
        }
    }

    IEnumerator damageCoroutine()
    {
        yield return new WaitForSeconds(flashTime);
        damageFlag = false;

    }

    void damageEffect()
    {

        animator.SetBool("damageFlag", damageFlag);
        print("ダメージアニメーション");

    }

    void gameOverCheck()
    {
        if(playerHP <= 0)
        {
            pLife.statsGameOver = true;
            print("ゲームオーバー");
        }
    }

    public int statsPlayerHP
    {
        set
        {
            playerHP = value;
        }
        get
        {
            return playerHP;
        }
    }

    void shotBullet()
    {
        interval += Time.deltaTime;
        if(Input.GetButton("Fire1") && interval >= waitTime)
        {
            interval = 0;
            Instantiate(this.bullets[mouseWheelCheck],
                new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + zValue),
                this.gameObject.transform.rotation);
        }
    }

    void Wheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mouseWheelCheck++;

            if(mouseWheelCheck > bullets.Length - 1)
            {
                mouseWheelCheck = 0;
            }
            print("マウスホイール:" + mouseWheelCheck);
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mouseWheelCheck--;
            if(mouseWheelCheck < 0)
            {
                mouseWheelCheck = bullets.Length - 1;
            }
            print("マウスホイール:" + mouseWheelCheck);
        }
        waitTime = bulletInterval[mouseWheelCheck];
    }
}
