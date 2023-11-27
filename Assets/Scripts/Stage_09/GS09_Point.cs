using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS09_Point : MonoBehaviour
{
    [SerializeField] EventData[] OnClearActions;
    [SerializeField] float waitTime;
    bool isEnter;
    bool isClear;
    [SerializeField] GS09_Rock rock;
    // �����v���C���[���Q�b�ԋߖT�ɂ���΁A������15�Ɉړ����ăN���A

    float timeCount;
    Character character;

    private void Update()
    {
        if (isClear)
        {
            return;
        }
        if (!rock.IsSet)
        {
            return;
        }
        if (isEnter)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= waitTime)
            {
                isClear = true;
                StartCoroutine(ClearAction());
                character.SetTarget(transform.position);
            }
        }
    }

    IEnumerator ClearAction()
    {
        foreach (var eventData in OnClearActions)
        {
            yield return eventData.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeCount = 0;
        isEnter = true;
        if (!character)
        {
            character = collision.GetComponent<Character>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timeCount = 0;
        isEnter = false;
    }
}
