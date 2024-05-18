using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket h�z�
    private Rigidbody2D rb; // Oyuncunun Rigidbody2D bile�eni
    private Vector2 movement; // Hareket vekt�r�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
    }

    void Update()
    {
        // Kullan�c�dan giri�leri al
        movement.x = Input.GetAxisRaw("Horizontal"); // A ve D tu�lar� ya da sol/sa� ok tu�lar�
        movement.y = Input.GetAxisRaw("Vertical");   // W ve S tu�lar� ya da yukar�/a�a�� ok tu�lar�
    }

    void FixedUpdate()
    {
        // Rigidbody2D ile hareketi uygula
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
