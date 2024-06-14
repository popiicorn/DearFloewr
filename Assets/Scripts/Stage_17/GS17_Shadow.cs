using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS17_Shadow : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    [SerializeField] UnityEvent OnCharacter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Character>())
        {
            OnCharacter?.Invoke();
        }
    }
}
