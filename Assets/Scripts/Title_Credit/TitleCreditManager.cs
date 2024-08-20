using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        BGMManager.Instance.OffAisac();
        GameManager.Instance.ToTitle();
    }
}
