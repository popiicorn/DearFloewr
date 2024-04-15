using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSelect : MonoBehaviour
{
    int size;
    public const float hotSpotX = 55 / 8;

    private void Start()
    {
        size = ((57 * 100 * Screen.width) / 1920) / 100;
    }
    public void SetCursor(Texture2D icon)
    {
        Cursor.SetCursor(ResizeTexture(icon, size, size), Vector2.one* hotSpotX, CursorMode.ForceSoftware);
    }

    Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }
}
