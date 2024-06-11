using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleDemo : MonoBehaviour
{
    [SerializeField] 
    bool canClick = true;
    [SerializeField] DOTweenAnimation fadeObj;
    string nextSceneName = "Transition_1";


    private void Awake()
    {
        // fadeObj.onComplete.AddListener(Transition);
    }

    public void OnStartGameButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        BGMManager.Instance.StopBGM();
        nextSceneName = "Transition_1";
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
