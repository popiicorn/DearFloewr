using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GS11_FlowerTrigger : MonoBehaviour
{
    [SerializeField] EventData[] OnTriggers;
    [SerializeField] ProCamera2D proCamera2D;
    [SerializeField] ProCamera2DCameraWindow proCamera2DCameraWindow;
    [SerializeField] GameObject enemies;
    [SerializeField] CameraShake cameraShake;
    // Character���ӂꂽ��G�t�F�N�g���o��
    [SerializeField] UnityEvent OnClear;

    public float shakeAmount = 0.7f;
    public float shakeDuration = 1.0f;

    private Vector3 originalPos;
    private float currentShakeDuration;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D");
        if (other.GetComponent<Character>())
        {
            StartCoroutine(Play());
        }
    }

    IEnumerator Play()
    {
        float time = Stage11Params.Instance.cameraMoveTime;
        StartCoroutine(cameraShake.ShakeLoop(Stage11Params.Instance.shakeSpan, Stage11Params.Instance.shakeAmount));
        foreach (var item in OnTriggers)
        {
            yield return item.Play();
        }
        // proCamera2D��Offset��X��DOTween���g����1�b������-1�ɂ���
        // 1�b������-1�ɂ���
        DOTween.To(() => proCamera2D.OffsetX, x => proCamera2D.OffsetX = x, -1, time).SetEase(Ease.Linear);
        proCamera2DCameraWindow.enabled = true;
        // proCamera2DCameraWindow��X��DOTween���g����1�b������0.5�ɂ���
        DOTween.To(() => proCamera2DCameraWindow.CameraWindowRect.x, x => proCamera2DCameraWindow.CameraWindowRect.x = x, 0.5f, time).SetEase(Ease.Linear);
        yield return new WaitForSeconds(time);
        enemies.SetActive(true);
        yield return new WaitForSeconds(Stage11Params.Instance.fadeStartTime);
        OnClear?.Invoke();
    }
}
