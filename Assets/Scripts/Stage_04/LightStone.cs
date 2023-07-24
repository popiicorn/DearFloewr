using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStone : Gimmick
{
    [SerializeField] int id;
    [SerializeField] GameObject lightEF;

    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    public override Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {
            return rightPos;
        }
        return leftPos;
    }

    public override void Move(Vector3 distance)
    {
        Debug.LogError("ERROR");
    }

    // クリックされたら
    // ターゲットをこいつにしてPlayerが近づいてくる
    // 近くまできたら「キック」をする
    // キックされたら特定の効果を実行する

    public override void OnGameCharacter(Character character)
    {
        StartCoroutine(Anim(character));
    }

    IEnumerator Anim(Character character)
    {
        character.BusyMode();
        yield return new WaitForSeconds(0.5f);
        character.KickGimmick();
        yield return new WaitForSeconds(0.3f);
        if (LightStoneManager.Instance.IsCorrect(id))
        {
            lightEF.SetActive(true);
        }
        character.SetDefaultMode();
    }

    public void LightOff()
    {
        lightEF.SetActive(false);
    }

}
