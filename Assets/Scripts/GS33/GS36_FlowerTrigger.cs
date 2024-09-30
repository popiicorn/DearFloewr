using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS36_FlowerTrigger : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        SetNone();
    }

    public void SetNone()
    {
        bool wasGet = SaveManager.Instance.CheckGetBonus();
        if (wasGet)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
