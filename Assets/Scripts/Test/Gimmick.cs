using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    public bool IsLock { get; protected set; }

    public abstract Transform GetTargetPosition(Vector3 playerPos);

    public abstract void Move(Vector3 distance);
}
