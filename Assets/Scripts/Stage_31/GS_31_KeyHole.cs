using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

// KeyHoke��Key�̃h���b�v��ƂȂ�
public class GS_31_KeyHole : MonoBehaviour, IDropHandler
{
    [SerializeField] EventData[] eventDatas;
    // �h���b�v���ꂽ���ɌĂ΂��
    public void OnDrop(PointerEventData eventData)
    {
        // �h���b�v���ꂽ�I�u�W�F�N�g���擾����
        var dropObj = eventData.pointerDrag;

        // �h���b�v���ꂽ�I�u�W�F�N�g��Key��������
        if (dropObj.TryGetComponent(out GS_31_Key key))
        {
            // Key�̈ʒu���AKeyHole�̈ʒu�ɂ���
            // ������Dotweenw���g���ĂȂ߂炩�Ɉړ�������
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
