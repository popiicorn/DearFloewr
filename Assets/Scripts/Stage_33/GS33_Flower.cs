using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS33_Flower : MonoBehaviour
{
    // クリックされるとエフェクトを再生
    public UnityAction OnClickAction;

    public void OnClick()
    {
        OnClickAction?.Invoke();
        CriManager.instance.PlayObjSE("GetPetal");
    }
}
