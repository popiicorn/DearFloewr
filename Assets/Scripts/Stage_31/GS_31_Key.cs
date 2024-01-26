using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
// �}�E�X�Ńh���b�O&�h���b�v�ł���悤�ɂ���
public class GS_31_Key : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // �I�t�Z�b�g������āA�N���b�N�����ʒu�Ƃ̍�����ێ�����
    Vector3 offset;
    // Drop�ł���悤�ɂ���
    CanvasGroup canvasGroup;
    [SerializeField] GameObject effect;
    [SerializeField] EventData[] onBeginDrag;


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        // �N���b�N�����ʒu�ƁA�I�u�W�F�N�g�̈ʒu�̍�����ێ�����
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        StartCoroutine(PlayEvent());
    }

    IEnumerator PlayEvent()
    {
          foreach (var eventData in onBeginDrag)
        {
            yield return eventData.Play();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Canvas��RenderMode��ScreenSpace - Camera�̏ꍇ�A
        // eventData.position�̓J�����̃X�N���[�����W�Ȃ̂ŁA
        // �J�����̃��[���h���W�ɕϊ�����
        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        screenToWorldPoint.z = 0;

        // �I�u�W�F�N�g�̈ʒu���A�N���b�N�����ʒu�ƃI�t�Z�b�g�𑫂����ʒu�ɂ���
        transform.position = screenToWorldPoint + offset;
        // Canvas�̉�ʊO�ɏo�Ȃ��悤�ɂ���BLocalPosition�Ŕ��肷��
        Vector3 localPosition = transform.localPosition;
        float buff = 100f;
        // ��ʃT�C�Y�ɂ���ĕς���K�v������
        localPosition.x = Mathf.Clamp(localPosition.x, -Screen.width/2f+ buff, Screen.width / 2f- buff);
        localPosition.y = Mathf.Clamp(localPosition.y, -Screen.height / 2f + buff, Screen.height / 2f- buff);
        transform.localPosition = localPosition;




    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
    
    // �G�t�F�N�g���\��
    public void OnSetKey()
    {
        effect.SetActive(false);
    }
}
