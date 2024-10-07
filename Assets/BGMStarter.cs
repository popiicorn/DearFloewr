using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BGMManager.Instance.StartBGM();
        Debug.Log("スターター");
    }

   
}
