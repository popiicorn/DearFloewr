using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_31_DarkTrigger : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    [SerializeField] GameObject darkPanel;
    // 2D�v���W�F�N�g��Character������������
    // �E�J������h�炷
    // �E��ʂ��Â�����
    // ��x�������s����
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
