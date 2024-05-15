using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using DG.Tweening;
public class GS5_ClearAction : MonoBehaviour
{
    [SerializeField] ProCamera2D camera2D;

    public void MoveCamera()
    {
        DOTween.To(() => camera2D.OffsetX, x => camera2D.OffsetX = x, 0.6f, 1).SetEase(Ease.Linear);
    }
}
