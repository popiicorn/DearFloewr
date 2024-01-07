using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_KeyManager : MonoBehaviour
{
    [SerializeField] EventData[] ClearEvents;
    bool isFlowerClear = false;
    bool isWrapClear = false;


    public void SetWrapGimmickClear()
    {
        isWrapClear = true;
        CheckClear();
    }

    public void SetFlowerGimmickClear()
    {
        isFlowerClear = true;
        CheckClear();
    }

    void CheckClear()
    {
          if (isWrapClear && isFlowerClear)
        {
            StartCoroutine(PlayClearEvent());
        }
    }

    IEnumerator PlayClearEvent()
    {
        foreach (var eventData in ClearEvents)
        {
            yield return eventData.Play();
        }
    }
}
