using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket hýzý
    private Rigidbody2D rb; // Oyuncunun Rigidbody2D bileþeni
    private Vector2 movement; // Hareket vektörü

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
    }

    void Update()
    {
        // Kullanýcýdan giriþleri al
        movement.x = Input.GetAxisRaw("Horizontal"); // A ve D tuþlarý ya da sol/sað ok tuþlarý
        movement.y = Input.GetAxisRaw("Vertical");   // W ve S tuþlarý ya da yukarý/aþaðý ok tuþlarý
    }

    void FixedUpdate()
    {
        // Rigidbody2D ile hareketi uygula
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
