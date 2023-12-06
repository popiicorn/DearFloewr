using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS10_Pomp : MonoBehaviour
{
    public UnityEvent OnPompComp;

    public void PompComp()
    {
        OnPompComp?.Invoke();
    }

}
