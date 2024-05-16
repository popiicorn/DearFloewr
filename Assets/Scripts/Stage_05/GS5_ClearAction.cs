using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class GS5_ClearAction : MonoBehaviour
{
    [SerializeField] ProCamera2D camera2D;
    [SerializeField] UnityEvent OnClear;
    [SerializeField] float time = 1;

    public void MoveCamera()
    {
        DOTween.To(() => camera2D.OffsetX, x => camera2D.OffsetX = x, 0.6f, time).SetEase(Ease.Linear).OnComplete(() => OnClear?.Invoke());
    }
}
