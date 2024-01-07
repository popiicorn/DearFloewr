using UnityEngine;

public class SetDefaultCursor : MonoBehaviour
{
    [SerializeField] Texture2D icon;
    int size;
    private void Start()
    {
        Debug.Log(Screen.width);
        size = ((57*100*Screen.width)/1920)/100;
        SetCursor(icon);
    }

    public void SetCursor(Texture2D icon)
    {
        // Cursor.SetCursor(icon, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.SetCursor(ResizeTexture(icon, size,size), new Vector2(55/2, 55 / 2), CursorMode.ForceSoftware);
    }

    Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }
}
