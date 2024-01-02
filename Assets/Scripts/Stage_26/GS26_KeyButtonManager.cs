using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS26_KeyButtonManager : MonoBehaviour
{
    [SerializeField] GS26_KeyButton[] keyButtons;
    [SerializeField] int[] correctKeys;
    int index = 0;
    private void Awake()
    {
        keyButtons = GetComponentsInChildren<GS26_KeyButton>(true);
        foreach (GS26_KeyButton keyButton in keyButtons)
        {
            keyButton.OnClickAction += SetAction;
        }
    }

    public void SetAction(int keyNumber)
    {
        if (correctKeys[index] == keyNumber)
        {
            keyButtons[index].PlayLineAnimator();
            index++;
        }

        if (index == correctKeys.Length)
        {
            Debug.Log("ê≥â");
        }
    }
}
