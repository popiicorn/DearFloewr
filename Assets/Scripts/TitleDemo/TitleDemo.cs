using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDemo : MonoBehaviour
{
    bool canClick = true;
    public void OnStartGameButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        FadeManager.Instance.LoadScene("Transition_1", 1.0f);
    }

    public void OnCreditButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        FadeManager.Instance.LoadScene("Title_Credit", 1.0f);
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
}
