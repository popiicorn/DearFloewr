using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCreditManager : MonoBehaviour
{
    bool canClick = true;
    public void OnBackButton()
    {
        if (!canClick)
        {
            return;
        }
        canClick = false;
        FadeManager.Instance.LoadScene("Title_Demo", 1.0f);
    }
}
