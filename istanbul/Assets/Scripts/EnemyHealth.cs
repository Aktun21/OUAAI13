using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Düþmanýn maksimum caný
    private int currentHealth; // Düþmanýn mevcut caný
    public GameManager GameManager; // GameManager nesnesi
    public float timeToAddOnDeath = 5f; // Düþman öldüðünde eklenmesi gereken süre

    void Start()
    {
        currentHealth = maxHealth;
        GameManager = GameObject.FindObjectOfType<GameManager>(); // GameManager nesnesini bul
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Hasar al
                Destroy(other.gameObject); // Mermiyi yok et
            }
        }
    }

    void TakeDamage(int damage)
    {
        // Düþmanýn canýný azalt
        currentHealth -= damage;

        // Eðer düþmanýn caný sýfýra veya daha az olursa
        if (currentHealth <= 0)
        {
            if (GameManager != null)
            {
                GameManager.AddTime(timeToAddOnDeath);
            }
            Die(); // Düþmaný yok et
        }
    }

    void Die()
    {
        // Düþmaný yok et
        Destroy(gameObject);
    }
}
