using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BornuthFlower : MonoBehaviour
{
    [SerializeField] GameObject flowerObj;
    bool wasGet;

    // �N���b�N�����ƃt�����[��\��
    public void ShowFlower()
    {
        if (wasGet) return;
        wasGet = true;
        flowerObj.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }
}
