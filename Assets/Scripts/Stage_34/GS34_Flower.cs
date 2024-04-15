using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS34_Flower : MonoBehaviour
{
    // 花が咲くときに、連動して隣の花がつぼみになる:近所を英語で何と言うか -> neighbor
    [SerializeField] GS34_Flower[] neighborFlowers;
    GS34_Bud selfBut;
    // 花が咲いているかどうか
    bool isBloomed = false;

    public bool IsBloomed { get => isBloomed; }

    public void SetSelfBut(GS34_Bud bud)
    {
        selfBut = bud;
    }


    // 花がサク
    public void Bloom(bool isPair = false)
    {
        if (isBloomed)
        {
            return;
        }
        selfBut.gameObject.SetActive(false);
        isBloomed = true;
        // 花を表示する
        gameObject.SetActive(true);
        if (isPair)
        {
            return;
        }
        // 隣の花をつぼみにする
        foreach (var flower in neighborFlowers)
        {
            flower.Bud();
        }
    }

    // 花がつぼみ
    public void Bud()
    {
        if (!isBloomed)
        {
            return;
        }
        isBloomed = false;
        // 花を非表示にする
        gameObject.SetActive(false);
        selfBut.ShowBud();
    }
}
