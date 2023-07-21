using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    bool isStart;

    public void OnStart()
    {
        if (isStart)
        {
            return;
        }
        isStart = true;
        FadeManager.Instance.LoadScene("Main", 1f);
    }
}
