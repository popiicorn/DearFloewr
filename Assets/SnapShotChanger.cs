using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class SnapShotChanger : MonoBehaviour
{
    //[SerializeField] CriAtomSource[] atomsource;

    private void Start()
    {
        ChangeSnapshotOn();
    }

    public void ChangeSnapshotOn()
    {
        CriAtomEx.ApplyDspBusSnapshot("on", 1);
    }
    public void ChangeSnapshotOff()
    {
        CriAtomEx.ApplyDspBusSnapshot("off", 1);
    }
}
