using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS28_Hole : MonoBehaviour
{
    void Start()
    {
        GetComponent<QuestionObj>().enabled = false;
    }
    // Boxが離れたら、クリック可能にする
    private void OnTriggerExit2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    // Boxがぶつかったら、クリック不可能にする
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
}
