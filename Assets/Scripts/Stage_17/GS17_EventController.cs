using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GS17_EventController : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    [SerializeField] CameraShake cameraShake;
    public static int index;
    bool isGameOver;
    string stageName;
    void Start()
    {
        // イベントの開始
        StartCoroutine(EventStart());
        stageName = SceneManager.GetActiveScene().name;
    }

    IEnumerator EventStart()
    {
        // イベントの数だけ繰り返す
        for (int i = index; i < eventDatas.Length; i++)
        {
            // イベントの開始
            yield return eventDatas[i].Play();
        }
        index = 2;
    }

    public void Shake()
    {
        StartCoroutine(cameraShake.Shake(Stage17Params.Instance.shakeSpan, Stage17Params.Instance.shakeAmount, Stage17Params.Instance.shakeTime));
    }


    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        FadeManager.Instance.LoadScene(stageName, 1);
    }
}
