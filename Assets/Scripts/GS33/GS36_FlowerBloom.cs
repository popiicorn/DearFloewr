using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS36_FlowerBloom : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;
    [SerializeField] Animator animator;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(true);
    }

    private void OnEnable()
    {
        BloomAnim();
    }
    void BloomAnim()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }

    public void PlayVacuum()
    {
        animator.Play("Flower_Vacuum_GS36", 0, 0);
    }
}
