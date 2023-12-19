using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GS17_ShadowManager : MonoBehaviour
{
    [SerializeField] GameObject[] shadows;
    [SerializeField] UnityEvent Clear;
    int index = -1;

    public void ShowNext()
    {
        index++;
        if (index >= shadows.Length)
        {
            Clear.Invoke();
            return;
        }
        shadows[index].SetActive(true);
    }
}
