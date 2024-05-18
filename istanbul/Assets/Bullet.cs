using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Merminin verdi�i hasar
    public bool isPlayerBullet = true; // Merminin oyuncu taraf�ndan m� yoksa d��man taraf�ndan m� ate�lendi�ini kontrol etmek i�in

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            if (isPlayerBullet && !health.isPlayer)
            {
                // Oyuncunun mermisi d��mana �arpt�
                health.TakeDamage(damage);
            }
            else if (!isPlayerBullet && health.isPlayer)
            {
                // D��man�n mermisi oyuncuya �arpt�
                health.TakeDamage(5);
            }
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
