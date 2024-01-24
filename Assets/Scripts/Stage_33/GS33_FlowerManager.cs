using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS33_FlowerManager : MonoBehaviour
{
    // 子要素の花のリスト
    GS33_Flower[] flowers;
    int count = 0;

    // 全ての花をクリックした時のイベント
    public UnityEvent OnClickAllFlowers;


    void Start()
    {
        // 子要素の花のリストを取得
        flowers = GetComponentsInChildren<GS33_Flower>(true);

        // 花のクリック時の処理を設定
        foreach (var flower in flowers)
        {
            flower.OnClickAction = OnClickFlower;
        }
    }

    // 花がクリックされた時の処理
    void OnClickFlower()
    {
        Debug.Log("花がクリックされた");
        count++;
        if (count == flowers.Length)
        {
            OnClickAllFlowers?.Invoke();
        }
    }

}
