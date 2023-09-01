using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS08_Flower : MonoBehaviour
{
    [SerializeField] GameObject[] flowers;
    [SerializeField] EventData OnCompleteEvent;
    int index;
    public void ShowFlower()
    {
        flowers[index].SetActive(false);
        index++;
        flowers[index].SetActive(true);
        if (index == 3)
        {
            StartCoroutine(OnCompleteEvent.Play());
        }
    }
    public void SetInit()
    {
        foreach (var item in flowers)
        {
            item.SetActive(false);
        }
        index = 0;
        flowers[index].SetActive(true);
    }
}
