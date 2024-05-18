using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool isPlayer = false; // Bu nesnenin oyuncu olup olmad���n� kontrol etmek i�in

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isPlayer)
        {
            // Oyuncu �l�rse yap�lacak i�lemler
            Debug.Log("Player Died");
            // Oyun sonu i�lemleri burada yap�labilir
        }
        else
        {
            // D��man �l�rse yap�lacak i�lemler
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(25); // Oyuncunun sa�l���n� artt�r
            }
            Destroy(gameObject); // D��man� yok et
        }
    }
}
