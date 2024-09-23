using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage08_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] shadows;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameClear)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var shadow in shadows)
            {
                shadow.SetActive(false);
            }
        }
    }

    public void OnRestart()
    {
        foreach (var shadow in shadows)
        {
            shadow.SetActive(true);
        }
    }
}
