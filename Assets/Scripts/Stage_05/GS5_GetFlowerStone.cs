using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS5_GetFlowerStone : GetFlowerStone
{
    // �΂��T��R������Ԃ��擾
    // �΂��R���
    [SerializeField] Transform target;
    protected override void Update()
    {
        if (wasGetFlower)
        {
            return;
        }
        if (!canKick && target.position.x >= 28.7f)
        {
            canKick = true;
            GetComponent<Collider2D>().enabled = true;
        }
        else if (canKick && target.position.x < 28.7f)
        {
            canKick = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }




   
}
