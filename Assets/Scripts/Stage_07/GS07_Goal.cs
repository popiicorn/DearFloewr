using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS07_Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();
        if (character)
        {
            GameManager.Instance.GameClear();
            character.SetDefaultMode();
        }
    }
}
