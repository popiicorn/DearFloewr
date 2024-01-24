using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS33_GoalDoor : MonoBehaviour
{
    [SerializeField] EventData[] eventDatas;

    bool isClear = false;
    // Player�����̃R���C�_�[�ɓ�������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            if (isClear) return;

            isClear = true;
            // �C�x���g�����s
            StartCoroutine(ExecuteEvent());
        }
    }

    // �C�x���g�����s
    IEnumerator ExecuteEvent()
    {
        foreach (var eventData in eventDatas)
        {
            yield return eventData.Play();
        }
    }
}
