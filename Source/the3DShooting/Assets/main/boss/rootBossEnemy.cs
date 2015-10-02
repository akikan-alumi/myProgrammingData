/*
 * ボスのアニメーション及び弾発射クラス
 */
using UnityEngine;
using System.Collections;

public class rootBossEnemy : MonoBehaviour
{

    public GameObject upperSpawn;
    public GameObject downerSpawn;
    public GameObject needle;
    public int animValue=4;

    private Animator animator;
    private int _180Rotate_instanceEnemy;
    private int _180RotateRebirth_instanceEnemy;
    private int _360RotateRight;
    private int _360RotateLeft;
    private float instantiateTime = 0.1f;
    private bool instantiateFlag = false;


    void Start()
    {
        this.animator = GetComponent<Animator>();
        _180Rotate_instanceEnemy = Animator.StringToHash("Base Layer.180Rotate_instanceEnemy");
        _180RotateRebirth_instanceEnemy = Animator.StringToHash("Base Layer.180RotateRebirth_instanceEnemy");
        _360RotateRight = Animator.StringToHash("Base Layer.360RotateRight");
        _360RotateLeft = Animator.StringToHash("Base Layer.360RotateLeft");
        StartCoroutine("instGameObject");
        
    }
    void Update()
    {
        animatorState();
    }

    void animatorState()
    {
        AnimatorStateInfo stateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.fullPathHash == _180Rotate_instanceEnemy ||
            stateInfo.fullPathHash == _180RotateRebirth_instanceEnemy ||
            stateInfo.fullPathHash == _360RotateLeft ||
            stateInfo.fullPathHash == _360RotateRight)
        {
            instantiateFlag = true;
        }
        else
        {
            instantiateFlag = false;
            animationTransition();
        }
    }

    void animationTransition()
    {
        if(!instantiateFlag)
        {
            int trans = Random.Range(0, animValue);
            print("次の攻撃を選択中");
            switch(trans)
            {
                case 0:
                    animator.SetInteger("transition",trans);
                    break;
                case 1:
                    animator.SetInteger("transition",trans);
                    break;
                case 2:
                    animator.SetInteger("transition",trans);
                    break;
                case 3:
                    animator.SetInteger("transition",trans);
                    break;
                default:
                    Debug.LogError("rootBossEnemyにて不正なランダム数値が入力されました");
                    break;
            }
        }
        
    }

    IEnumerator instGameObject()
    {
        while(true)
        {
            if(instantiateFlag)
            {

                Instantiate(needle, upperSpawn.transform.position, upperSpawn.transform.rotation);
                Instantiate(needle, downerSpawn.transform.position, downerSpawn.transform.rotation);
                print("コルーチンでインスタンス生成");
            }
            yield return new WaitForSeconds(instantiateTime);
        }
    }
}
