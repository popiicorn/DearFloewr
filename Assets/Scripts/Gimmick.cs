using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gimmick 
{
    public void OnClickAction();

    public Transform GetTargetPosition(Vector3 playerPos);
}
