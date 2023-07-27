using UnityEngine;

public class SetDefaultCursor : MonoBehaviour
{
    [SerializeField] Texture2D icon;

    private void Awake()
    {
        SetCursor(icon);
    }

    public void SetCursor(Texture2D icon)
    {
        Cursor.SetCursor(icon, Vector2.zero, CursorMode.ForceSoftware);
    }
}
