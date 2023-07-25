using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS06_Monitor : MonoBehaviour
{
    public UnityAction OnPushed;
    [SerializeField] GameObject[] icons;
    int index;
    bool power = false;

    public int Index { get => index; }

    private void Awake()
    {
        index = 0;
        power = false;
        icons[index].SetActive(power);
    }


    public void ChangeIcon()
    {
        if (!power)
        {
            return;
        }
        icons[index].SetActive(false);
        index++;
        if (index >= icons.Length)
        {
            index = 0;
        }
        icons[index].SetActive(true);
        OnPushed?.Invoke();
    }

    public void Power()
    {
        power = !power;
        icons[index].SetActive(power);
    }

    void HideAllIcon()
    {
        foreach (var icon in icons)
        {
            icon.SetActive(false);
        }
    }
}
