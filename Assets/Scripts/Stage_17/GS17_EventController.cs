using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GS17_EventController : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    [SerializeField] CameraShake cameraShake;
    static int index;
    bool isGameOver;
    string stageName;
    void Start()
    {
        // �C�x���g�̊J�n
        StartCoroutine(EventStart());
        stageName = SceneManager.GetActiveScene().name;
    }

    IEnumerator EventStart()
    {
        // �C�x���g�̐������J��Ԃ�
        for (int i = index; i < eventDatas.Length; i++)
        {
            // �C�x���g�̊J�n
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
