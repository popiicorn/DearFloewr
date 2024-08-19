using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StageSelectPanel : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float moveToRightX;
    [SerializeField] float moveToLeftX;
    [SerializeField] Ease ease;
    public void PanelMoveToRight()
    {

        transform.DOLocalMoveX(moveToRightX, duration).SetEase(ease);
    }

    public void PanelMoveToLeft()
    {
        transform.DOLocalMoveX(moveToLeftX, duration).SetEase(ease);
    }
}
