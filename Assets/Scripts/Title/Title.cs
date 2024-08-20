using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    bool canClick = true;
    [SerializeField] DOTweenAnimation fadeObj;
    string nextSceneName = "Title_StageSelect";

    public void OnStartGameButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        BGMManager.Instance.StopBGM();
        nextSceneName = "Title_StageSelect";
        fadeObj.gameObject.SetActive(true);
    }

    public void OnCreditButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        nextSceneName = "Title_Credit";
        fadeObj.gameObject.SetActive(true);
        BGMManager.Instance.OnAisac();

    }

    public void OnExitButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        Application.Quit();
    }

    public void Transition()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
    }
}
