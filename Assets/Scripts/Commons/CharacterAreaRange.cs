using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAreaRange : MonoBehaviour
{
    [SerializeField] bool exitLimit;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    private void LateUpdate()
    {
        if (exitLimit)
        {
            Vector2 newPos = transform.position;
            newPos.x = Mathf.Clamp(transform.position.x, leftPos.position.x, rightPos.position.x);
            transform.position = newPos;
        }
    }
}
