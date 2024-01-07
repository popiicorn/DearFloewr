using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS26_KeyButton : MonoBehaviour
{
    [SerializeField] int keyNumber;

    public UnityAction<int> OnClickAction;

    Animator lineAnimator;

    void Awake()
    {
        lineAnimator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        OnClickAction?.Invoke(keyNumber);
    }

    public void PlayLineAnimator()
    {
        lineAnimator.Play("KeyButton_Push");
    }

    public void PlayPush()
    {
        lineAnimator.Play("KeyButton_PushOnly");
    }
    public void PlayIdle()
    {
        lineAnimator.Play("KeyButton_Idle");
    }
}