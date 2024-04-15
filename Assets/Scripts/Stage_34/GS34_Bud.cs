using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS34_Bud : MonoBehaviour
{
    [SerializeField] GS34_Flower selfFlower;
    GS34_FlowerGroup groupFlowers;

    // クリックされたら
    // ・花オブジェクトを咲かせる（表示する）
    // ・すでに咲いている場合は変化しない
    // ・連動する花オブジェクトを咲かせる

    private void Awake()
    {
        selfFlower.SetSelfBut(this);
        groupFlowers = GetComponentInParent<GS34_FlowerGroup>();
    }

    public void OnClick()
    {
        Debug.Log("OnClick");
        selfFlower.Bloom(true);
        groupFlowers.Bloom();
    }

    // つぼみとして表示する
    public void ShowBud()
    {
        gameObject.SetActive(true);
    }
}
