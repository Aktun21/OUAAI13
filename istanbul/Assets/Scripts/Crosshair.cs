using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture; // Crosshair sprite'�
    public Vector2 crosshairOffset = new Vector2(16, 16); // Sprite merkezini ayarlamak i�in

    void Start()
    {
        Cursor.visible = false; // Default cursor'u gizle
    }

    void OnGUI()
    {
        // Crosshair sprite'�n� fare pozisyonuna �iz
        Vector2 mousePosition = Event.current.mousePosition;
        Rect crosshairRect = new Rect(mousePosition.x - crosshairOffset.x, mousePosition.y - crosshairOffset.y, crosshairTexture.width, crosshairTexture.height);
        GUI.DrawTexture(crosshairRect, crosshairTexture);
    }
}
