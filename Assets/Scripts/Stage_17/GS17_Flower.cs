using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS17_Flower : MonoBehaviour
{
    // Characterぶつかったら、揺れるアニメーションを再生
    ParticleSystem particle;
    Animator animator;
    bool isDancing;
    [SerializeField] EventData[] vacuumEvent;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDancing)
        {
            Debug.Log(collision.tag);
            if (collision.CompareTag("Shadow"))
            {
                collision.gameObject.SetActive(false);
                StartCoroutine(Vacuum());
            }
            return;
        }
        if (collision.GetComponent<Character>())
        {
            StartCoroutine(DanceFlower());
        }
    }

    IEnumerator Vacuum()
    {
        foreach (var item in vacuumEvent)
        {
            yield return item.Play();
        }
    }

    IEnumerator DanceFlower()
    {
        isDancing = true;
        animator.Play("Flower_Dance");
        particle.Play();
        // 3秒後に消える
        yield return new WaitForSeconds(3);
        particle.Stop();
        animator.Play("Flower_Idle");
        isDancing = false;
    }
}
