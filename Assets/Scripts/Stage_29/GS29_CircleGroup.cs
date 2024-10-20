using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GS29_CircleGroup : MonoBehaviour
{
    [SerializeField] GS29_Circle[] circles;
    [SerializeField] EventData[] OnClearEvent;
    bool isClear;
    private void Start()
    {
        foreach(GS29_Circle circle in circles)
        {
            circle.OnComplete += Check;
        }
    }

    void Check()
    {
        if (isClear)
        {
            return;
        }
        // 2つとも回転が完了していたら
        if (circles[0].IsComplete && circles[1].IsComplete)
        {
            isClear = true;
            // 画面を揺らす

            // 2つの円を止める
            foreach (GS29_Circle circle in circles)
            {
                circle.Stop();
            }
            StartCoroutine(PlayAnim());
        }
    }

    IEnumerator PlayAnim()
    {
        foreach(EventData eventData in OnClearEvent)
        {
            yield return eventData.Play();
        }
    }


    public void Unlock()
    {
        foreach (GS29_Circle circle in circles)
        {
            circle.Unlock();
        }
    }
}