using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Düþmanýn maksimum caný
    private int currentHealth; // Düþmanýn mevcut caný
    public GameManager GameManager; // GameManager nesnesi
    public float timeToAddOnDeath = 15f; // Düþman öldüðünde eklenmesi gereken süre

    void Start()
    {
        currentHealth = maxHealth;
        GameManager = GameObject.FindObjectOfType<GameManager>(); // GameManager nesnesini bul
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // Null referans hatasý oluþturabilecek nesneyi kontrol et
            if (GameManager != null)
            {
                TakeDamage(); // Hasar al
                Destroy(other.gameObject); // Mermiyi yok et
            }
        }
    }

    void TakeDamage()
    {
        // Düþmanýn canýný azalt
        currentHealth -= 35; // Örnek olarak oyuncu mermisinin 35 hasar verdiðini varsayalým
                             // GameManager'a süre ekle
        
        // Eðer düþmanýn caný sýfýra veya daha az olursa
        if (currentHealth <= 0)
        {
            GameManager.AddTime(timeToAddOnDeath);
            Die(); // Düþmaný yok et
        }
    }

    void Die()
    {
       
        // Düþmaný yok et
        Destroy(gameObject);

      
    }
}
