using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS29_MiniGame : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GS29_Capsule capsule;
    [SerializeField] EventData[] OnClearEvents;
    bool isPlaying = false;
    bool isClear;


    public void Show()
    {
        canvas.SetActive(true);
        isPlaying = true;
    }

    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                capsule.AddForce();
            }
        }
    }

    public void Clear()
    {
        StartCoroutine(PlayClearEvent());
    }

    IEnumerator PlayClearEvent()
    {
        foreach (var item in OnClearEvents)
        {
            yield return item.Play();
        }
    }
}
