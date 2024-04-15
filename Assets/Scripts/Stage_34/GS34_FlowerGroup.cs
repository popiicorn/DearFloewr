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
    // �x��č炩����
    IEnumerator DelayBlooms()
    {
        yield return new WaitForSeconds(bloomDelay);
        foreach (var flower in flowers)
        {
            flower.Bloom();
        }
        // ���ׂẲԂ��炢����A�Q�[���N���A
        OnBloom?.Invoke();

    }

    // ���ׂẲԂ��炢�Ă��邩�ǂ���
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

    // ���ׂẲԂ��ڂ݂ɂ���
    public void ResetFlowers()
    {
        foreach (var flower in flowers)
        {
            flower.Bud();
        }
    }
}
