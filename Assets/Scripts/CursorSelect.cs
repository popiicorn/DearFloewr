using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSelect : MonoBehaviour
{
    [SerializeField] Texture2D icon;

    void Start()
    {
        SetCursor(icon);
    }

    public void SetCursor(Texture2D icon)
    {
        Cursor.SetCursor(icon, Vector2.zero, CursorMode.ForceSoftware);
    }
}
