using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRockable 
{
    int Id { get; }
    void SetLock(bool isLock);
}
