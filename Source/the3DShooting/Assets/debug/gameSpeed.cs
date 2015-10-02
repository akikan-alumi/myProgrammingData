/*デバッグ用速度変更クラス*/
using UnityEngine;
using System.Collections;

public class gameSpeed : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Time.timeScale = 2.0f;
            print("Ｚキー押下");
        }

        if(Input.GetButtonUp("Jump"))
        {
            Time.timeScale = 1.0f;
            print("Ｚキー非押下");
        }
    }
}
