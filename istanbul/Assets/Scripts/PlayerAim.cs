using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    void Update()
    {
        // Fare konumunu d�nya koordinatlar�na d�n��t�r
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Z eksenini s�f�rla

        // Oyuncudan fareye do�ru olan y�n
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Oyuncunun rotasyonunu fare y�n�ne �evir
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
