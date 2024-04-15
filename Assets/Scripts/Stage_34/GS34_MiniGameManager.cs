using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS34_MiniGameManager : MiniGameBase
{

    // もし全ての花が咲いたら、ゲームクリア

    // 花のグループ
    [SerializeField] GS34_FlowerGroup[] flowerGroups;
    [SerializeField] List<EventData> OnAllBloomed;
    [SerializeField] SpriteRenderer corollaSpriterenderer;
    [SerializeField] float bloomDelay = 0.5f;
    // 花が咲くたびに調べる
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
        // すべての花をつぼみにする
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
