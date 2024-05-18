using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public bool isPlayer = false; // Bu nesnenin oyuncu olup olmadýðýný kontrol etmek için

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
            // Oyuncu ölürse yapýlacak iþlemler
            Debug.Log("Player Died");
            // Oyun sonu iþlemleri burada yapýlabilir
        }
        else
        {
            // Düþman ölürse yapýlacak iþlemler
            PlayerHealth playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(25); // Oyuncunun saðlýðýný arttýr
            }
            Destroy(gameObject); // Düþmaný yok et
        }
    }
}
