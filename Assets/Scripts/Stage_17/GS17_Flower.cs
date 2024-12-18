using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS17_Flower : MonoBehaviour
{
    // Characterぶつかったら、揺れるアニメーションを再生
    ParticleSystem particle;
    Animator animator;
    bool isDancing;
    bool isVacuuming;
    [SerializeField] EventData[] vacuumEvent;
    [SerializeField] CameraShake cameraShake;

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
                // collision.gameObject.SetActive(false);
                Destroy(collision.transform.parent.parent.gameObject);
                StopAllCoroutines();
                StartCoroutine(Vacuum());
            }
            return;
        }
        if (isVacuuming)
        {
            return;
        }
        if (collision.GetComponent<Character>())
        {
            StartCoroutine(DanceFlower());
        }
    }

    IEnumerator Vacuum()
    {
        isDancing = false;
        isVacuuming = true;
        StopDance();
        foreach (var item in vacuumEvent)
        {
            yield return item.Play();
            StartCoroutine(cameraShake.Shake(Stage17Params.Instance.shakeSpan, Stage17Params.Instance.shakeAmount, Stage17Params.Instance.shakeAmount));
        }
        isVacuuming = false;
        SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_5");
    }

    IEnumerator DanceFlower()
    {
        isDancing = true;
        animator.Play("Flower_Dance");
        particle.Play();
        // 3秒後に消える
        yield return new WaitForSeconds(3);
        StopDance();
    }

    public void StopDance()
    {
        particle.Stop();
        animator.Play("Flower_Idle");
        isDancing = false;
    }
}
