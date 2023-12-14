using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage11Params : MonoBehaviour
{
    public static Stage11Params Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public float shakeAmount = 0.3f;
    public float shakeSpan = 0.05f;
    // �t�F�[�h���J�n����܂ł̎���
    public float fadeStartTime;
}
