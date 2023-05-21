using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, Gimmick
{
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;

    public Transform GetTargetPosition(Vector3 playerPos)
    {
        if (transform.position.x < playerPos.x)
        {
            return rightPos;
        }
        return leftPos;
    }

    public void OnClickAction()
    {
        Debug.Log("岩をクリック");
        // 特定の場所まで移動させる
    }
}