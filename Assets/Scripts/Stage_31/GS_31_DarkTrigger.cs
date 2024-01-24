using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_31_DarkTrigger : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    [SerializeField] GameObject darkPanel;
    // 2DプロジェクトでCharacterがあたったら
    // ・カメラを揺らす
    // ・画面を暗くする
    // 一度だけ実行する
    bool isExecuted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isExecuted) return;
        if (collision.GetComponent<Character>() != null)
        {
            isExecuted = true;
            cameraShake.Do();
            darkPanel.SetActive(true);
        }
    }
}
