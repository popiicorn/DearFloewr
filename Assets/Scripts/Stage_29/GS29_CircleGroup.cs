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
        // 2�Ƃ���]���������Ă�����
        if (circles[0].IsComplete && circles[1].IsComplete)
        {
            isClear = true;
            // ��ʂ�h�炷

            // 2�̉~���~�߂�
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