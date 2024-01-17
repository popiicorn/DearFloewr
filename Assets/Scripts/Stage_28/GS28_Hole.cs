using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_Hole : MonoBehaviour
{
    void Start()
    {
        GetComponent<QuestionObj>().enabled = false;
    }
    // Box�����ꂽ��A�N���b�N�\�ɂ���
    private void OnTriggerExit2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    // Box���Ԃ�������A�N���b�N�s�\�ɂ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
}
