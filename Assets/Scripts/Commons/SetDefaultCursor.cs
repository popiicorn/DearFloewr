using UnityEngine;

public class SetDefaultCursor : MonoBehaviour
{
    [SerializeField] Texture2D icon;
    int size;
    [SerializeField] float hotSpotX = 0;
    private void Start()
    {
        size = ((57*100*Screen.width)/1920)/100;
        SetCursor(icon);
    }

    private void Update()
    {
        // Cursor.SetCursor(ResizeTexture(icon, size, size), new Vector2(1, 1)* hotSpotX, CursorMode.ForceSoftware);
    }

    public void SetCursor(Texture2D icon)
    {
        if (icon == null)
        {
            icon = this.icon;
        }
        Cursor.SetCursor(ResizeTexture(icon, size, size), Vector2.one*CursorSelect.hotSpotX, CursorMode.ForceSoftware);
    }

    Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }
}
