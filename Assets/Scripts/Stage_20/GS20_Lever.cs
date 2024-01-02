using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS20_Lever : MonoBehaviour
{
    [SerializeField] protected EventData[] eventDatas;
    protected Animator animator;
    protected bool isOn = false;
    protected bool isPlaying = false;

    public bool IsOn { set => isOn = value; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayEvent()
    {
        if (isPlaying) return;
        StartCoroutine(Play());
    }

    protected virtual IEnumerator Play()
    {
        isOn = true;
        isPlaying = true;
        animator.Play("lever_Solo");
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
        isPlaying = false;
    }

}
