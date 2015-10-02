/*
 ステージのUVを動かして、さも動いているように見せるクラス
 */

using UnityEngine;
using System.Collections;

public class moveUV : MonoBehaviour
{
    public GameObject gameObject;
    private Renderer rend;

    private float vecx = 0;
    private float vecy = 0;
    private float speed = 1f;

    void Start()
    {
        //レンダラーからマテリアルにアクセスしないとうまく動かない模様?　おのれUnity5
        this.rend = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        vecx = (vecx < 1) ? (vecx + speed * Time.deltaTime) : 0f;
        vecy = (vecy < 1) ? (vecy + speed * Time.deltaTime) : 0f;
        this.rend.material.SetTextureOffset("_MainTex", new Vector2(vecx, vecy));
    }
}
