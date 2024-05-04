using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS36_Enemy : MonoBehaviour
{
    bool isAlive = true;
    Animator animator;

    public UnityEvent OnAttackEvent;


    public bool IsAlive { get => isAlive; }

    // ì¡íËÇÃà íuÇ…çUåÇÇçsÇ§

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move()
    {
        animator.Play("Shadow_A_Attack", 0, 0);
    }

    public void Attack()
    {
        StartCoroutine(AttackAnim());
    }

    IEnumerator AttackAnim()
    {
        animator.Play("Shadow_A_Attack", 0, 0);
        yield return new WaitForSeconds(1f);
        OnAttackEvent?.Invoke();
    }

    public void Die()
    {
        isAlive = false;
    }

    public void ReShow()
    {
        if (isAlive)
        {
            animator.Play("Shadow_A_Fade", 0, 0);
        }
    }
}
