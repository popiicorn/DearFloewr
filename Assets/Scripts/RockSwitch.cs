using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSwitch : MonoBehaviour
{

    // もしRockがぶつかったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("岩がぶつかったよ");
    }
}
