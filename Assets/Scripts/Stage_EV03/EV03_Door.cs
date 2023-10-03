using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening;

public class EV03_Door : MonoBehaviour
{
    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] UnityEvent OnEndAction;
    int d = 100;
    public void CameraMoveLeft()
    {
        MoveCamera(1, false);
    }

    void MoveCamera(float endValue, bool exitEvent)
    {
        float nowNum = proCamera2D.CameraTargets[1].TargetInfluenceH;
        DOTween.To(() => nowNum, (x) => nowNum = x, endValue, EV03_Params.Instance.cameraMoveTime).SetEase(Ease.Linear)
            .OnUpdate(() => proCamera2D.CameraTargets[1].TargetInfluenceH = nowNum).OnComplete(() => OnEnd(exitEvent));
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
        MoveCamera(0, true);
    }
}
