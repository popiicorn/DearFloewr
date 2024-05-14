using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class Gimmick : MonoBehaviour
{
    public bool IsLock { get; set; }
    public float Size { get; protected set; }
    public bool IsMove { get; protected set; }
    public Transform CenterTransform { get => centerTransform == null ? transform : centerTransform ; }

    [SerializeField] Transform centerTransform;
    public bool isLimit; 
    public List<Transform> leftLimit;
    public List<Transform> rightLimit;
    public UnityAction OnLimit;
    public float limitOffsetR;
    public float limitOffsetL;

    public abstract Transform GetTargetPosition(Vector3 playerPos);

    public abstract void Move(Vector3 distance);

    public abstract void OnGameCharacter(Character character);

    public Transform GetLeftLimit()
    {
        foreach (var limit in leftLimit)
        {
            if(limit.gameObject.activeSelf)
            {
                return limit;
            }
        }
        return null;
    }
    public Transform GetRightLimit()
    {

        foreach (var limit in rightLimit)
        {
            if (limit.gameObject.activeSelf)
            {
                return limit;
            }
        }
        return null;
    }
}
