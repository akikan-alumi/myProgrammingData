using UnityEngine;
using System.Collections;

public class startObj : MonoBehaviour {
    private bool alphaSwitch;
    private float a;
    void Start() {
        a = 1f;
        alphaSwitch = false;
    }

    void Update() {
        if (alphaSwitch) {
            a -= 0.01f;
        }
    }
	// Use this for initialization
    void OnGUI() {

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, a);
        // 画面中心にグループを配置
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100));
        // 今度は長方形がすべてグループに調整

        // グループが画面上のどこにあるかが分かるよう、ボックスを作成します。
        GUI.Box(new Rect(0, 0, 200, 100), "黒いボタンを連打せよ！");
        if (GUI.Button(new Rect(60, 30, 80, 30), "START!")) {
            FadeManager.Instance.LoadLevel("mainScene", 0.1f);
            alphaSwitch = true;
            SoundManager.Instance.PlayBGM(0);
            SoundManager.Instance.PlayVoice(0);
        }

        // 上で開始したグループを終了
        GUI.EndGroup();
    }


}