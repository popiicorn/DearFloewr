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
        }
        else
        {
            timer = 0;
        }
    }
}
