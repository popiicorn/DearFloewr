using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS20_Button : MonoBehaviour
{

    [SerializeField] Sprite[] marks;
    SpriteRenderer spriteRenderer;
    int index = 0;
    public UnityAction OnClickEvent;

    public int Index { get => index; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = 0;
        spriteRenderer.sprite = marks[index];
    }
    public void OnClick()
    {
        index++;
        if(index >= marks.Length)
        {
            index = 0;
        }
        spriteRenderer.sprite = marks[index];
        OnClickEvent?.Invoke();
    }
}
