using UnityEngine;
using System.Collections;
using System;

public class countDownTimer : MonoBehaviour {
    [SerializeField]
    private float startTime; // seconds
    public float timer;
    public bool paused = true;
    public bool timeMinus = false;
    public Button button;
    public GUIStyleState styleState;
    private GUIStyle style;
    

    private void Awake() {
        reset();
        style = new GUIStyle();
        style.fontSize = 30;
    }

    private void reset() {
        StartCoroutine("StopMethod");
        startTime = 10.0f;
    }

    private void Update() {
        if (paused) return;
        timer -= Time.deltaTime;
        if (timer <= 0.0f) {
            timer = 0.0f;
            paused = true;
            timeMinus = false;
            button.finished();

        }
    }

    private void OnGUI() {
        if (timer != 0.0f) {//秒数のカウントダウン記述
            GUILayout.BeginArea(new Rect (0,0,Screen.width,Screen.height));
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal(GUILayout.Height(200));
            GUILayout.FlexibleSpace();
            GUILayout.Box(String.Format("{0:00}:{1:00}", Math.Floor(timer % 60f), timer % 1 * 100), GUILayout.Width(200));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.EndArea();
        }

        //結果発表処理
        if (timer == 0 && button.Score != 0 || button.count == 0) {
            Rect rect = new Rect(Screen.width / 2 - 40, Screen.height / 2 - 80, 0, 0);
            style.normal = styleState;
            GUI.Label(rect, button.Score + "連打!", style);
        }
        //画面遷移処理
        GUILayout.BeginArea(new Rect(0, 200, Screen.width, Screen.height));
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        
        
        if (button.Score != 0 || button.count == 0) {
            if (GUILayout.Button("もう一回！")) {
                    SoundManager.Instance.StopSE();
                    SoundManager.Instance.StopBGM();
                    SoundManager.Instance.PlayBGM(0);
                    SoundManager.Instance.StopVoice();
                    SoundManager.Instance.PlayVoice(0);
                    FadeManager.Instance.LoadLevel("mainScene", 0.1f);
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndArea();
    }
    private IEnumerator StopMethod() {
        yield return new WaitForSeconds(1.2f);
        timer = startTime;
        paused = false;
        timeMinus = true;
        
    }
}
