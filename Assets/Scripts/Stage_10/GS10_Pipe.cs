using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS10_Pipe : MonoBehaviour
{
    public UnityEvent OnAnimComp;

    public void AnimComp()
    {
        OnAnimComp?.Invoke();
    }
}
