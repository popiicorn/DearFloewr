using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS26_KeyFlower : MonoBehaviour
{
    [SerializeField] GameObject[] hanas;
    ParticleSystem flowerParticle;
    [SerializeField] UnityEvent OnClickEvent;
    [SerializeField] public UnityEvent OnClearEvent;

    int index = 0;
    bool isClear = false;

    private void Awake()
    {
        flowerParticle = GetComponentInChildren<ParticleSystem>();
    }
    public void OnClick()
    {
        if (isClear)
        {
            return;
        }
        flowerParticle.Play();
        hanas[index].SetActive(false);
        OnClickEvent?.Invoke();
        index++;
        if (index >= hanas.Length)
        {
            isClear = true;
            OnClearEvent?.Invoke();
        }
    }
}
