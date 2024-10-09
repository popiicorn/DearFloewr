using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS20_EmotionChecker : MonoBehaviour
{
    public void AddEmotionCount()
    {
        SaveManager.Instance.AddQuestionCount();
    }
}
