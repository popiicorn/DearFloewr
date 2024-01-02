using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS26_KeyFlower : MonoBehaviour
{
    [SerializeField] GameObject[] hanas;
    ParticleSystem flowerParticle;
    [SerializeField] UnityEvent OnClickEvent;

    int index = 0;

    private void Awake()
    {
        flowerParticle = GetComponentInChildren<ParticleSystem>();
    }
    public void OnClick()
    {
        if (index >= hanas.Length)
        {
            return;
        }
        flowerParticle.Play();
        hanas[index].SetActive(false);
        OnClickEvent?.Invoke();
        index++;
    }
}
