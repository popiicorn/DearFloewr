using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS28_Button : MonoBehaviour
{
    public enum ButtonType
    {
        Top,
        Center,
        Bottom
    }

    [SerializeField] ButtonType buttonType;

    public UnityAction<ButtonType> OnButtonPressed;

    public void OnClick()
    {
        OnButtonPressed?.Invoke(buttonType);
    }
}
