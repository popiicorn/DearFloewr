using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Com.LuisPedroFonseca.ProCamera2D;

public class EV03_Door : MonoBehaviour
{
    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] UnityEvent OnEndAction;

    public void CameraMoveLeft()
    {
        StartCoroutine(SmoothCameraMove(0,-0.01f, false));
    }

    IEnumerator SmoothCameraMove(int value, float d, bool exitEvent)
    {
        while (Mathf.Abs(proCamera2D.CameraTargets[0].TargetInfluenceH - value) > 0.02f)
        {
            proCamera2D.CameraTargets[0].TargetInfluenceH += d;
            yield return null;
        }
        proCamera2D.CameraTargets[0].TargetInfluenceH = value;
        if (exitEvent)
        {
            OnEndAction?.Invoke();
        }
    }
    public void CameraMoveDefault()
    {
        StartCoroutine(SmoothCameraMove(1,0.01f, true));
    }
}
