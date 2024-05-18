using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    void Update()
    {
        // Fare konumunu dünya koordinatlarýna dönüþtür
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Z eksenini sýfýrla

        // Oyuncudan fareye doðru olan yön
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Oyuncunun rotasyonunu fare yönüne çevir
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
