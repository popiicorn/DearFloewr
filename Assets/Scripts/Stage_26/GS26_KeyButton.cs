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
        Debug.Log("Button Clicked");
        OnClickAction?.Invoke(keyNumber);
    }

    public void PlayLineAnimator()
    {
        lineAnimator.Play("KeyButton_Push");
    }
}