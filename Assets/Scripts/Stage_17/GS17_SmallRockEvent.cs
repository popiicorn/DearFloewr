using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS17_SmallRockEvent : MonoBehaviour
{
    // ボーナスの花
    [SerializeField] float getTime;
    [SerializeField] BornuthFlower getFlower;
    [SerializeField] Character character;
    bool isGetFlower;

    // もしキャラが5秒座っていたら、花を取得

    float timer;
    bool isSit;
    void Start()
    {
        isGetFlower = getFlower.WasGet;
    }

    private void Update()
    {
        if (isGetFlower)
        {
            return;
        }
        if (character.CharaMode == Character.Mode.Sit)
        {
            timer += Time.deltaTime;
            if (timer >= getTime)
            {
                getFlower.ShowFlower();
                isGetFlower = true;
            }
            if (!isSit)
            {
                // 鳴らす
                Debug.Log("座ってる");
            }

            isSit = true;
        }
        else
        {
            timer = 0;
            if (isSit)
            {
                // 鳴らす
                Debug.Log("立ってる");
            }
            isSit = false;
        }
    }
}
