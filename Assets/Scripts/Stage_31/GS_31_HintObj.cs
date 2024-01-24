using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_31_HintObj : MonoBehaviour
{
    // Keyについている２Dコライダーがあたるとアニメーションを実行する
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.GetComponent<GS_31_Key>())
        {
            animator.Play("FadeIN");
        }
    }
    // 離れるとFadeOut
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GS_31_Key>())
        {
            animator.Play("FadeOUT");
        }
    }
}
