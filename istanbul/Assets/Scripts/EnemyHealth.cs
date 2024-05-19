using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // D��man�n maksimum can�
    private int currentHealth; // D��man�n mevcut can�
    public GameManager GameManager; // GameManager nesnesi
    public float timeToAddOnDeath = 15f; // D��man �ld���nde eklenmesi gereken s�re

    void Start()
    {
        currentHealth = maxHealth;
        GameManager = GameObject.FindObjectOfType<GameManager>(); // GameManager nesnesini bul
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // Null referans hatas� olu�turabilecek nesneyi kontrol et
            if (GameManager != null)
            {
                TakeDamage(); // Hasar al
                Destroy(other.gameObject); // Mermiyi yok et
            }
        }
    }

    void TakeDamage()
    {
        // D��man�n can�n� azalt
        currentHealth -= 35; // �rnek olarak oyuncu mermisinin 35 hasar verdi�ini varsayal�m
                             // GameManager'a s�re ekle
        
        // E�er d��man�n can� s�f�ra veya daha az olursa
        if (currentHealth <= 0)
        {
            GameManager.AddTime(timeToAddOnDeath);
            Die(); // D��man� yok et
        }
    }

    void Die()
    {
       
        // D��man� yok et
        Destroy(gameObject);

      
    }
}
