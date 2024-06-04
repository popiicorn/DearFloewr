using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS09_Rock : Rock
{
    [SerializeField] float timeOfActive;
    [SerializeField] float setPointX;
    // SetPoint�̈ʒu�ɂ���Η��t���O
    [SerializeField] bool isSet;
    int leftArea = 4;
    int rightArea = 5;
    public bool IsSet { get => isSet; }

    private void Update()
    {
        if (Mathf.Abs(transform.localPosition.x - setPointX) < float.Epsilon)
        {
            isSet = true;
        }
        else
        {
            isSet = false;
        }
        if (!isSet && leftArea <= transform.localPosition.x && transform.localPosition.x <= rightArea)
        {
            Debug.Log("Rock");
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(setPointX, transform.localPosition.y, transform.localPosition.z), timeOfActive * Time.deltaTime * 3);
        }
    }

    // ����̈ʒu�ɗ����玩���ňړ����ē���

}