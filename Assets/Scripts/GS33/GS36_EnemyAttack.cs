using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;
public class GS36_EnemyAttack : MonoBehaviour
{
    [SerializeField] bool debugMode;
    [SerializeField] int debugAttackPos;
    Animator animator;
    [SerializeField] GS36_FlowerManager flowerManager;
    [SerializeField] Transform animTrans;
    [SerializeField] CameraShake cameraShake;
    public UnityAction<bool> OnAttacked;
    [SerializeField] Character character;
    [SerializeField] float delayTime = 0.5f;
    int[] attackPosList = new int[3] { -7, 0, 7 };

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Attack()
    {
        // Ç«Ç±Ç…çUåÇÇ∑ÇÈÇ©åàÇﬂÇÈ
        int attackId = Random.Range(0, 3);
        if (debugMode)
        {
            attackId = debugAttackPos;
        }
        animTrans.transform.localPosition = new Vector3(attackPosList[attackId], 0, 0);
        StartCoroutine(CharacterMove(flowerManager.SelectedFlowerId));
        if (attackId == flowerManager.SelectedFlowerId)
        {
            StartCoroutine(AttackMissAnim());
        }
        else
        {
            StartCoroutine(AttackSuccessAnim());
        }
    }

    IEnumerator CharacterMove(int index)
    {
        Debug.Log("CharacterMove");
        StartCoroutine(cameraShake.Shake(0.02f, 0.7f, 100f / 60f));
        character.KickGimmick();
        // à⁄ìÆ
        CriManager.instance.PlayObjSE("ShadowQwake");
        yield return character.transform.DOMoveX(GetTargetPos(index), 100f/60f).SetEase(Ease.Linear).WaitForCompletion();
        character.enabled = true;
        character.SetDefaultMode();
    }

    int GetTargetPos(int index)
    {
        switch (index)
        {
            default:
            case 0:
                return 0;
            case 1:
                return 7;
        }
    }

    IEnumerator AttackMissAnim()
    {
        animator.Play("AttackMiss", 0, 0);
        yield return new WaitForSeconds(3f);
        flowerManager.CurrentFlower.PlayVacuum();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(cameraShake.Shake(0.02f, 2, 0.2f));
        StartCoroutine(OnEndAttack(0.5f, true));
    }
    IEnumerator AttackSuccessAnim()
    {
        animator.Play("AttackSuccess", 0, 0);
        float time = 3.12f;
        yield return new WaitForSeconds(time);
        StartCoroutine(cameraShake.Shake(0.02f, 2, 0.2f));
        StartCoroutine(OnEndAttack(4.5f- time, false));
    }


    IEnumerator OnEndAttack(float time, bool attack)
    {
        yield return new WaitForSeconds(time);
        flowerManager.ResetFlower();
        yield return new WaitForSeconds(delayTime);
        OnAttacked?.Invoke(attack);
    }
    bool isGameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameOver)
        {
            return;
        }
        if (collision.TryGetComponent(out Character chatacter))
        {
            isGameOver = true;
            Debug.Log("Ç‘Ç¬Ç©Ç¡ÇΩ");
            chatacter.gameObject.SetActive(false);
            GameManager.Instance.GameOver();
            CriManager.instance.PlayObjSE("GameOver");
        }
    }
}
