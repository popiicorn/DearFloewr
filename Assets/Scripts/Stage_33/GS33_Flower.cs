using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS33_Flower : MonoBehaviour
{
    bool isGet = false;
    // �N���b�N�����ƃG�t�F�N�g���Đ�
    public UnityAction OnClickAction;

    public void OnClick()
    {
        if (isGet)
        {
            return;
        }
        isGet = true;
        OnClickAction?.Invoke();
        CriManager.instance.PlayObjSE("GetPetal");
    }
}
