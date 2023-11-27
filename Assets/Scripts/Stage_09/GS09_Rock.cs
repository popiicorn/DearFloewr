using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_Rock : Rock
{
    [SerializeField] float timeOfActive;
    [SerializeField] float setPointX;
    // SetPoint�̈ʒu�ɂ���Η��t���O
    [SerializeField] bool isSet;

    public bool IsSet { get => isSet; }

    private void Update()
    {
        if (Mathf.Abs(transform.localPosition.x - setPointX) < 0.2f)
        {
            isSet = true;
        }
        else
        {
            isSet = false;
        }
    }
}