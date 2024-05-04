using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gimmick : MonoBehaviour
{
    public bool IsLock { get; set; }
    public float Size { get; protected set; }
    public bool IsMove { get; protected set; }

    public abstract Transform GetTargetPosition(Vector3 playerPos);

    public abstract void Move(Vector3 distance);

    public abstract void OnGameCharacter(Character character);
}
