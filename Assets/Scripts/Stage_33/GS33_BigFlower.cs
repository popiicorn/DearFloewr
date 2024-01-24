using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening;
using UnityEngine.Events;
public class GS33_BigFlower : MonoBehaviour
{
    //�J�����̈ʒu���グ��
    // ���̂��߂�ProCamera2D����Offset��0.3�ɕω�������

    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] UnityEvent OnMovedEvent;
    [SerializeField] EventData[] eventDatas;

    bool canClick = false;
    public void Start()
    {
        // proCamera2D.OffsetY = 0.3f;
        // DOTween���g���āA�J�����̈ʒu���グ��
        // �ړ����I�������A�C�x���g���Ăяo��
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
    // �N���b�N�����movie�A�j���[�V�������Đ�����
    public void OnClick()
    {
        if (!canClick) return;

        // �C�x���g�f�[�^�����ԂɎ��s����
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
