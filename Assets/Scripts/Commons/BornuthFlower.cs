using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BornuthFlower : MonoBehaviour
{
    [SerializeField] GameObject flowerObj;

    // クリックされるとフラワーを表示
    public void ShowFlower()
    {
        flowerObj.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }
}
