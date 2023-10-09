using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_EV00 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeManager.Instance.LoadScene("Stage_EV01", 1f);
        }
    }
}
