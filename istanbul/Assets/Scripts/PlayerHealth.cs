using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager; // GameManager nesnesi

    void OnTriggerEnter2D(Collider2D other)
    {
        // D��man�n mermisiyle temas etti�inde
        if (other.CompareTag("EnemyBullet"))
        {
            // GameManager'deki PlayerHitByBullet() fonksiyonunu �a��r
            gameManager.PlayerHitByBullet();
            // Mermiyi yok et
            Destroy(other.gameObject);
        }
    }
}
