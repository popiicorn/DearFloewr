using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS29_LeverEvent : MonoBehaviour
{
    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] UnityEvent OnEndAction;
    public float cameraMoveSpeed = 0.98f;
    int d = 100;


    public void CameraMoveLeft()
    {

        MoveCamera(-0.5f, true);
    }

    void MoveCamera(float endValue, bool exitEvent)
    {
        float nowNum = proCamera2D.OffsetX;
        DOTween.To(() => nowNum, (x) => nowNum = x, endValue, cameraMoveSpeed).SetEase(Ease.Linear)
            .OnUpdate(() => proCamera2D.OffsetX = nowNum).OnComplete(() => OnEnd(exitEvent));
    }

    void OnEnd(bool exitEvent)
    {
        if (exitEvent)
        {
            OnEndAction?.Invoke();
        }
    }
    public void CameraMoveDefault()
    {
        MoveCamera(0, false);
    }
}
