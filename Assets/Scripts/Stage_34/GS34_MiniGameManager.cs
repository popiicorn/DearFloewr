using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS34_MiniGameManager : MiniGameBase
{

    // �����S�ẲԂ��炢����A�Q�[���N���A

    // �Ԃ̃O���[�v
    [SerializeField] GS34_FlowerGroup[] flowerGroups;
    [SerializeField] List<EventData> OnAllBloomed;
    [SerializeField] SpriteRenderer corollaSpriterenderer;
    [SerializeField] float bloomDelay = 0.5f;
    // �Ԃ��炭���тɒ��ׂ�
    bool isMiniGameClear = false;
    void Awake()
    {
        flowerGroups = GetComponentsInChildren<GS34_FlowerGroup>();

        foreach (var group in flowerGroups)
        {
            group.OnBloom += CheckAllBloomed;
            group.SetBloomDelay(bloomDelay);
        }
    }

    void CheckAllBloomed()
    {

        if (isMiniGameClear)
        {
            return;
        }
        foreach (var group in flowerGroups)
        {
            if (!group.CheckAllBloomed())
            {
                return;
            }
        }
        isMiniGameClear = true;

        corollaSpriterenderer.color = new Color(1, 1, 1, 1);
        Debug.Log("Game Clear");
        StartCoroutine(MiniGameClear());
    }

    IEnumerator MiniGameClear()
    {
        foreach (var eventData in OnAllBloomed)
        {
            yield return eventData.Play();
        }
    }

    public void OnResetButton()
    {
        if (isMiniGameClear)
        {
            return;
        }
        // ���ׂẲԂ��ڂ݂ɂ���
        foreach (var group in flowerGroups)
        {
            group.ResetFlowers();
        }
    }

    public override void Close()
    {
        if (isMiniGameClear)
        {
            return;
        }
        base.Close();
    }
}
