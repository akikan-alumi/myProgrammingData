using UnityEngine;
using System.Collections;

public class DeathAlpha : MonoBehaviour {
    public float fadeTime = 1f;

    private float currentRemainTime;
    private SpriteRenderer spRenderer;
    private bool Swich; 
    // Use this for initialization
    void Start() {
        // 初期化
        currentRemainTime = fadeTime;
        spRenderer = GetComponent<SpriteRenderer>();
        Swich = false;
    }

    // Update is called once per frame
    void Update() {
        if (Swich) {
            // 残り時間を更新
            currentRemainTime -= Time.deltaTime;

            if (currentRemainTime <= 0f) {
                // 残り時間が無くなったら自分自身を消滅
                GameObject.Destroy(this.gameObject);
                return;
            }

            // フェードアウト
            float alpha = currentRemainTime / fadeTime;
            var color = spRenderer.color;
            color.a = alpha;
            spRenderer.color = color;
        }
	}
    public void setSwitch() {
        this.Swich = true;
    }
}
