using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
public class GS20_FlowerGetObj : MonoBehaviour
{
    bool isClicked = false;
    // クリックすると左に動く
    // 一度クリックされると、クリックできなくなる
    public void OnClick()
    {
        if (isClicked) return;
        isClicked = true;
        // 左に移動：最初と最後が遅くなる
        transform.DOMoveX(1.8f, 2).SetEase(Ease.Linear);
        GetComponent<BoxCollider2D>().enabled = false;
        //transform.DOMoveX(1.8f, 3).SetEase(Ease.InOutQuint);
    }
}
