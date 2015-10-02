/*
 * プレイヤーの弾の管理クラス（ボツ）
 */
using UnityEngine;
using System.Collections;

public class bulletManager : MonoBehaviour
{

    public GameObject[] bullets;
    private int mouseWheelCheck;

    void Start()
    {
        mouseWheelCheck = 0;
    }

    void Update()
    {
        Wheel();
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
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mouseWheelCheck--;
            if(mouseWheelCheck < 0)
            {
                mouseWheelCheck = bullets.Length - 1;
            }
        }
        print("マウスホイール:" + mouseWheelCheck);
    }
}
