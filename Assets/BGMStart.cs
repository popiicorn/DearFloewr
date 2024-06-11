using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string name= BGMManager.Instance.bGMCueName;
        BGMManager.Instance.StartBGM(name);
    }

    
}
