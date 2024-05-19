using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture; // Crosshair sprite'ý
    public Vector2 crosshairOffset = new Vector2(16, 16); // Sprite merkezini ayarlamak için

    void Start()
    {
        Cursor.visible = false; // Default cursor'u gizle
    }

    void OnGUI()
    {
        // Crosshair sprite'ýný fare pozisyonuna çiz
        Vector2 mousePosition = Event.current.mousePosition;
        Rect crosshairRect = new Rect(mousePosition.x - crosshairOffset.x, mousePosition.y - crosshairOffset.y, crosshairTexture.width, crosshairTexture.height);
        GUI.DrawTexture(crosshairRect, crosshairTexture);
    }
}
