using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager; // GameManager nesnesi

    void OnTriggerEnter2D(Collider2D other)
    {
        // Düþmanýn mermisiyle temas ettiðinde
        if (other.CompareTag("EnemyBullet"))
        {
            // GameManager'deki PlayerHitByBullet() fonksiyonunu çaðýr
            gameManager.PlayerHitByBullet();
            // Mermiyi yok et
            Destroy(other.gameObject);
        }
    }
}
