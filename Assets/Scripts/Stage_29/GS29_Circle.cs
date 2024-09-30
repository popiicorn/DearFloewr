using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GS29_Circle : MonoBehaviour
{
    [SerializeField] Collider2D m_Collider;
    [SerializeField] float rotationSpeed;
    [SerializeField] float rotationAngle;
    float defaultRotationAngle;
    public UnityAction OnComplete;
    bool isComplete;
    bool canRotate = false;

    public bool IsComplete { get => isComplete; }

    void Start()
    {
        defaultRotationAngle = transform.rotation.eulerAngles.z;
    }

    public void Unlock()
    {
        canRotate = true;
        // m_Collider.enabled = true;
    }

    public void Rotation()
    {
        if (!canRotate)
        {
            return;
        }
        canRotate = false;

        defaultRotationAngle += rotationAngle;
        if (defaultRotationAngle%360 == 0)
        {
        }
        // rotationAngle‚¾‚¯‚È‚ß‚ç‚©‚É‰ñ“]
        transform.DORotate(new Vector3(0, 0, defaultRotationAngle), rotationSpeed).SetEase(Ease.Linear).OnComplete(Check);
        CriManager.instance.PlayObjSE("blockMove_1");
    }

    void Check()
    {
        canRotate = true;
        if (Mathf.Abs(transform.rotation.eulerAngles.z)%360 < 0.1f)
        {
            Debug.Log(gameObject.name + "‚Ì‰ñ“]‚ªŠ®—¹‚µ‚Ü‚µ‚½");
            isComplete = true;
            OnComplete?.Invoke();
        }
    }

    public void Stop()
    {
        canRotate = false;
    }
}
