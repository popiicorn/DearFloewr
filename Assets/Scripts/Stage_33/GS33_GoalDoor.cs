using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS33_GoalDoor : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;

    bool isClear = false;
    // Playerがこのコライダーに入ったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            if (isClear) return;

            isClear = true;
            // イベントを実行
            StartCoroutine(ExecuteEvent());
        }
    }

    // イベントを実行
    IEnumerator ExecuteEvent()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
