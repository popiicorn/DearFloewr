using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class GS08_Meter : MonoBehaviour
{
    int index = 0;
    int maxValue = 3;
    [SerializeField] Transform[] posList;
    [SerializeField] UnityEvent OnComplete;
    [SerializeField] Transform meter;
    public void Move()
    {
        index++;
        meter.transform.DOMove(posList[index].position, 1f).OnComplete(() => OnComplete?.Invoke());
    }

    public void ResetPos()
    {
        index = 0;
        meter.transform.DOMove(posList[index].position, 1f);
    }
}
