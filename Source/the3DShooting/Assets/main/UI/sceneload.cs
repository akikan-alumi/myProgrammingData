/*
 * 非同期にシーンをロードしてリトライの体感速度を早める
 */
using UnityEngine;
using System.Collections;

public class sceneload : MonoBehaviour
{
    private AsyncOperation async;

    void Start()
    {
        StartCoroutine("loadThisScene");
    }

    void Update()
    {

    }
    IEnumerator loadThisScene()
    {
        //非同期シーンロード
        async = Application.LoadLevelAsync("main");
        async.allowSceneActivation = false;
        while(!async.isDone)
        {
            Debug.Log(async.progress * 100 + "%");

            yield return new WaitForSeconds(0);
        }
        yield return async;

    }

    public void retryButton()
    {
        async.allowSceneActivation = true;
        
    }
}
