using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage33_FlowerTrigger : MonoBehaviour
{
    bool isTriggered = false;
    [SerializeField] GameObject flower;
    // 2DのCharacterがぶつかると、イベントを発生させる

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered) return;
        if (collision.GetComponent<Character>())
        {
            isTriggered = true;
            flower.SetActive(true);
        }
    }
}
