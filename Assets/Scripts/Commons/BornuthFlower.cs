using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class BornuthFlower : MonoBehaviour
{
    [SerializeField] GameObject flowerObj;
    [SerializeField] private bool wasGet;
    [SerializeField] bool isCharaLock = false;

    public bool WasGet { get => SaveManager.Instance.CheckGetBonus(); }
    public bool IsCharaLock { get => isCharaLock; }

    private void Start()
    {
        wasGet = SaveManager.Instance.CheckGetBonus();
        if (wasGet && TryGetComponent(out Collider2D col))
        {
            col.enabled = false;
        }
        if (wasGet && TryGetComponent(out Image image))
        {
            image.enabled = false;
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
        if (TryGetComponent(out Collider2D col))
        {
            col.enabled = false;
        }
        if (TryGetComponent(out Image image))
        {
            image.enabled = false;
        }
        SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_2");
    }
}
