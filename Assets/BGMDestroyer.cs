using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDestroyer : MonoBehaviour
{
   public void DestroyBGMManager()
    {
        BGMManager.Instance.DestroyBGM();
    }
}
