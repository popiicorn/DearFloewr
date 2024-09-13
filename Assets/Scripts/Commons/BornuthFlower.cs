using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BornuthFlower : MonoBehaviour
{
    [SerializeField] GameObject flowerObj;
    private bool wasGet;

    public bool WasGet { get => SaveManager.Instance.CheckGetBonus(); }

    private void Start()
    {
        wasGet = SaveManager.Instance.CheckGetBonus();
        Debug.Log(wasGet);
        if (wasGet && TryGetComponent(out Collider2D col))
        {
            col.enabled = false;
        }
    }

    // クリックされるとフラワーを表示
    public virtual void ShowFlower()
    {
        wasGet = SaveManager.Instance.CheckGetBonus();
        if (wasGet) return;

        wasGet = true;
        flowerObj.SetActive(true);
        SaveManager.Instance.SetBonus();
        SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_2");
        if (TryGetComponent(out Collider2D col))
        {
            col.enabled = false;
        }
    }
}
