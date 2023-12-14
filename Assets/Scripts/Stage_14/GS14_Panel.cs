using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS14_Panel : MonoBehaviour
{
    // クリックしたときにパーツを回転させる
    public void OnClick()
    {
        Debug.Log("クリックしたよ");
        // パーツを回転させる
        GS14_MiniGameManager.Instance.CurrentPart.Rotate();
    }
}
