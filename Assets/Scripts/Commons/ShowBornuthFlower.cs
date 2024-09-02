using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShowBornuthFlower : BornuthFlower
{
    [SerializeField] UnityEvent OnAction;

    public override void ShowFlower()
    {
        base.ShowFlower();
    }
}
