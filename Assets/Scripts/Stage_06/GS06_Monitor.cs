using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS06_Monitor : MonoBehaviour
{
    public UnityAction OnPushed;
    public UnityEvent NoReaction;
    [SerializeField] GameObject[] icons;
    int index;
    bool power = false;

    public int Index { get => index; }

    private void Awake()
    {
        index = 3;
        power = false;
        icons[index].SetActive(power);
    }


    public void ChangeIcon()
    {
        if (!power)
        {
            NoReaction?.Invoke();
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
}
