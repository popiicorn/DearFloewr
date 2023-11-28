using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS08_Flower : MonoBehaviour
{
    [SerializeField] GameObject[] flowers;
    [SerializeField] List<EventData> OnCompleteEvent;
    int index;
    public void ShowFlower()
    {
        flowers[index].SetActive(false);
        index++;
        flowers[index].SetActive(true);
        if (index == 3)
        {
            StartCoroutine(Play());
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

    // OnCompleteEvent‚ğ‚·‚×‚ÄÀs‚·‚éŠÖ”
    IEnumerator Play()
    {
        foreach (var item in OnCompleteEvent)
        {
            yield return item.Play();
        }
    }


}
