using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening;
using UnityEngine.Events;
public class GS33_BigFlower : MonoBehaviour
{
    //カメラの位置を上げる
    // そのためにProCamera2D内のOffsetを0.3に変化させる

    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] UnityEvent OnMovedEvent;
    [SerializeField] EventData[] eventDatas;

    bool canClick = false;
    public void Start()
    {
        // proCamera2D.OffsetY = 0.3f;
        // DOTweenを使って、カメラの位置を上げる
        // 移動が終わったら、イベントを呼び出す
        DOTween.To(
            () => proCamera2D.OffsetY,
            (value) => proCamera2D.OffsetY = value,
            0.3f,
            0.5f
            ).OnComplete(() => MovedEvent());
    }
    void MovedEvent()
    {
        OnMovedEvent?.Invoke();
        canClick = true;
    }
    // クリックするとmovieアニメーションを再生する
    public void OnClick()
    {
        if (!canClick) return;

        // イベントデータを順番に実行する
        StartCoroutine(PlayEventDatas());
    }
    IEnumerator PlayEventDatas()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }

}
