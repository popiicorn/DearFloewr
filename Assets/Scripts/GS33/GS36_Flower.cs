using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS36_Flower : MonoBehaviour
{
    Animator animator;
    GS36_FlowerBeans flowerBeans;
    GS36_FlowerBloom flowerBloom;
    [SerializeField] UnityEvent OnBloom;
    public UnityAction<int> OnSelectedEvent;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        flowerBeans = GetComponentInChildren<GS36_FlowerBeans>();
        flowerBloom = GetComponentInChildren<GS36_FlowerBloom>(true);
        flowerBeans.OnSelected += OnSelected;
    }

    public void BloomAnim()
    {
        OnBloom?.Invoke();
    }

    public void ResetToInit()
    {
        animator.Play("FlowerGlowdown", 0, 0);
    }

    void OnSelected(int id)
    {
        OnSelectedEvent?.Invoke(id);
    }

    public void PlayVacuum()
    {
        flowerBloom.PlayVacuum();
    }

    public void SetLock(bool isLock)
    {
        flowerBeans.IsLock = isLock;
    }
}
