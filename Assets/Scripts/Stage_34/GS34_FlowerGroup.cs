using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS34_FlowerGroup : MonoBehaviour
{
    [SerializeField] List<GS34_Flower> flowers;
    public UnityAction OnBloom;
    float bloomDelay = 0.5f;
    
    void Awake()
    {
        flowers = new List<GS34_Flower>(GetComponentsInChildren<GS34_Flower>(true));
    }

    public void SetBloomDelay(float delay)
    {
        bloomDelay = delay;
    }

    public void Bloom()
    {
        StopAllCoroutines();
        StartCoroutine(DelayBlooms());
    }
    // 遅れて咲かせる
    IEnumerator DelayBlooms()
    {
        yield return new WaitForSeconds(bloomDelay);
        foreach (var flower in flowers)
        {
            flower.Bloom();
        }
        // すべての花が咲いたら、ゲームクリア
        OnBloom?.Invoke();

    }

    // すべての花が咲いているかどうか
    public bool CheckAllBloomed()
    {
        foreach (var flower in flowers)
        {
            if (!flower.IsBloomed)
            {
                return false;
            }
        }
        return true;
    }

    // すべての花をつぼみにする
    public void ResetFlowers()
    {
        foreach (var flower in flowers)
        {
            flower.Bud();
        }
    }
}
