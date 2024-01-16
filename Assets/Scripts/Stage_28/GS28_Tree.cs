using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS28_Tree : Gimmick
{
    [SerializeField] int id;

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] GS28_Lever lever;

    Animator animator;
    int kickCount = 0;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        return rightPos;
    }

    public override void Move(Vector3 distance)
    {
        return;
    }

    // クリックされたら
    // ターゲットをこいつにしてPlayerが近づいてくる
    // 近くまできたら「キック」をする
    // キックされたら特定の効果を実行する

    public override void OnGameCharacter(Character character)
    {
        if (kickCount >=3)
        {
            character.SetDefaultMode();
            return;
        }
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.3f);
        character.KickGimmick();
        kickCount++;
        yield return new WaitForSeconds(0.3f);
        animator.SetInteger("KickCount", kickCount);
        yield return new WaitForSeconds(0.2f);
        character.SetDefaultMode();
        if (kickCount >= 3)
        {
            lever.SetCanMove();
        }
    }
}
