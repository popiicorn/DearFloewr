using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GS29_HoleGoal : MonoBehaviour
{
    // カプセルが触れたら、カプセルを吸い込む
    [SerializeField] EventData[] OnGoalEvents;
    [SerializeField] Transform nextPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GS29_Capsule capsule = collision.GetComponent<GS29_Capsule>();
        if (capsule)
        {
            capsule.gameObject.SetActive(false);
            capsule.transform.position = nextPos.position;
            StartCoroutine(Goal());
            CriManager.instance.PlayObjSE("ObjSet");

            // capsule.StopForce();
            // collision.gameObject.transform.DOMove(transform.position, 0.5f);
            // collision.gameObject.transform.DOScale(0, 0.5f);
        }
    }

    IEnumerator Goal()
    {
        foreach (var item in OnGoalEvents)
        {
            yield return item.Play();
        }
    }

}
