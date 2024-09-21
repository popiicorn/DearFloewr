using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;

public class GS27_FlowerPickupParent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // オフセットを作る
    Vector3 offset;
    // 初期ポジション
    Vector3 initPos;
    public bool isClearPos = false;
    // Spriterendererをマウスでドラッグする
    bool canMove = true;
    bool isClear = false;
    CanvasGroup canvasGroup;
    void Awake()
    {
        initPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // ドラッグ開始
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isClear)
        {
            return;
        }

        PointerEventData pointerData = eventData as PointerEventData;

        // マウスの位置を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // オフセットを作る
        offset = transform.position - mousePos;
        canvasGroup.blocksRaycasts = false;
        // GetComponent<Collider2D>().enabled = false;
        CriManager.instance.PlayObjSE("ObjCatch");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canMove)
        {
            return;
        }
        PointerEventData pointerData = eventData as PointerEventData;

        // マウスの位置を取得
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // オフセットを足す
        transform.position = mousePos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isClearPos)
        {
            return;
        }
        transform.position = initPos;
        canvasGroup.blocksRaycasts = true;
        canMove = true;
        // GetComponent<Collider2D>().enabled = true;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClear)
        {
            return;
        }
        if (collision.GetComponent<GS27_CapsuleInside>())
        {
            isClearPos = true;
            canMove = false;
            isClear = true;
            CriManager.instance.PlayObjSE("GetPetal");
            GS27_Capsule.Instance.OnFlower();
            return;
        }

        if (collision.GetComponent<GS27_CapsuleUnder>())
        {
            canMove = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<GS27_CapsuleOutside>())
        {
            canMove = false;
        }
    }
}
