using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;

public class GS27_FlowerPickupParent : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // �I�t�Z�b�g�����
    Vector3 offset;
    // �����|�W�V����
    Vector3 initPos;
    public bool isClearPos = false;
    // Spriterenderer���}�E�X�Ńh���b�O����
    bool canMove = true;
    bool isClear = false;
    CanvasGroup canvasGroup;
    void Awake()
    {
        initPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // �h���b�O�J�n
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isClear)
        {
            return;
        }

        PointerEventData pointerData = eventData as PointerEventData;

        // �}�E�X�̈ʒu���擾
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // �I�t�Z�b�g�����
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

        // �}�E�X�̈ʒu���擾
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // �I�t�Z�b�g�𑫂�
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
