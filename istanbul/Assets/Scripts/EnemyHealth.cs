using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // D��man�n maksimum can�
    private int currentHealth; // D��man�n mevcut can�
    public GameManager GameManager; // GameManager nesnesi
    public float timeToAddOnDeath = 5f; // D��man �ld���nde eklenmesi gereken s�re

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
        // D��man�n can�n� azalt
        currentHealth -= damage;

        // E�er d��man�n can� s�f�ra veya daha az olursa
        if (currentHealth <= 0)
        {
            if (GameManager != null)
            {
                GameManager.AddTime(timeToAddOnDeath);
            }
            Die(); // D��man� yok et
        }
    }

    void Die()
    {
        // D��man� yok et
        Destroy(gameObject);
    }
}
