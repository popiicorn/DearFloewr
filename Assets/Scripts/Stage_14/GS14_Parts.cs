using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class GS14_Parts : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // �I�t�Z�b�g�����
    Vector3 offset;
    // �����|�W�V����
    Vector3 initPos;
    // Spriterenderer���}�E�X�Ńh���b�O����

    CanvasGroup canvasGroup;
    void Awake()
    {
        initPos = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // �h���b�O�J�n
    public void OnBeginDrag(PointerEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;

        // �}�E�X�̈ʒu���擾
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // �I�t�Z�b�g�����
        offset = transform.position - mousePos;
        canvasGroup.blocksRaycasts = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;

        // �}�E�X�̈ʒu���擾
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(pointerData.position);
        mousePos.z = 0;

        // �I�t�Z�b�g�𑫂�
        transform.position = mousePos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initPos;
        canvasGroup.blocksRaycasts = true;
        GetComponent<Collider2D>().enabled = true;
    }

    // �p�[�c����]������
    public void Rotate()
    {
        // ���S�����ɉ�]������
        // transform.rotation = Quaternion.Euler(0, 0, -90);

        // transform.RotateAround(transform.position, new Vector3(0, 0, 1), -90);
        transform.Rotate(new Vector3(0, 0, -90));
    }
}
