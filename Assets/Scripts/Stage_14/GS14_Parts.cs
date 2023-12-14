using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GS14_Parts : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // オフセットを作る
    Vector3 offset;
    // 初期ポジション
    Vector3 initPos;
    // Spriterendererをマウスでドラッグする

    CanvasGroup canvasGroup;
    void Awake()
    {
        initPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // ドラッグ開始
    public void OnBeginDrag(PointerEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;

        // マウスの位置を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // オフセットを作る
        offset = transform.position - mousePos;
        canvasGroup.blocksRaycasts = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;

        // マウスの位置を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // オフセットを足す
        transform.position = mousePos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initPos;
        canvasGroup.blocksRaycasts = true;
        GetComponent<Collider2D>().enabled = true;
    }

    // パーツを回転させる
    public void Rotate()
    {
        // 中心を軸に回転させる
        // transform.rotation = Quaternion.Euler(0, 0, -90);

        // transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90);
        transform.Rotate(new Vector3(0, 0, -90));
    }
}
