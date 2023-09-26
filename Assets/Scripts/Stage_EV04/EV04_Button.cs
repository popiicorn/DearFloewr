using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EV04_Button : MonoBehaviour
{
    Image image;
    bool isOn;

    [SerializeField] Color onColor;
    [SerializeField] Color offColor;

    public bool IsOn { get => isOn; }

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void OnClick()
    {
        isOn = !isOn;
        if (isOn)
        {
            image.color = onColor;
        }
        else
        {
            image.color = offColor;
        }
    }
}
