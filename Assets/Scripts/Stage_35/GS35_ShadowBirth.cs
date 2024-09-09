using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS35_ShadowBirth : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] Collider2D attackedCollider;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.3f);
        OnShadowBirth();
    }

    public void OnShadowBirth()
    {
        character.gameObject.SetActive(true);
        SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_15");
        gameObject.SetActive(false);
        attackedCollider.enabled = true;
    }
}
