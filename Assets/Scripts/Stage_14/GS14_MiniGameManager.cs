using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS14_MiniGameManager : MonoBehaviour
{
    [SerializeField] GS14_Parts[] parts;
    [SerializeField]int index = 0;
    [SerializeField] EventData[] eventDatas;

    public static GS14_MiniGameManager Instance { get; private set; }


    public GS14_Parts CurrentPart { get { return parts[index]; } }

    void Awake()
    {
        Instance = this;
    }
    public void SetNextPart()
    {
        index++;
        if (index >= parts.Length)
        {
            // �Q�[���N���A�N���A
            StartCoroutine(Play());
            CriManager.instance.PlayObjSE("quake00");
            return;
        }
        CurrentPart.gameObject.SetActive(true);
    }

    // eventDatas���Đ�����  
    IEnumerator Play()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
