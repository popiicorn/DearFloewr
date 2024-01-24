using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

// KeyHokeはKeyのドロップ先となる
public class GS_31_KeyHole : MonoBehaviour, IDropHandler
{
    [SerializeField] EventData[] eventDatas;
    // ドロップされた時に呼ばれる
    public void OnDrop(PointerEventData eventData)
    {
        // ドロップされたオブジェクトを取得する
        var dropObj = eventData.pointerDrag;

        // ドロップされたオブジェクトがKeyだったら
        if (dropObj.TryGetComponent(out GS_31_Key key))
        {
            // Keyの位置を、KeyHoleの位置にする
            // ただしDotweenwを使ってなめらかに移動させる
            key.transform.DOMove(transform.position, 0.5f).OnComplete(() => OnSetKey());
        }
    }

    public void OnSetKey()
    {
        StartCoroutine(EventsPlay());
    }
    IEnumerator EventsPlay()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
