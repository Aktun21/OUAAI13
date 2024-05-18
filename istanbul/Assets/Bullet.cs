using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Merminin verdiði hasar
    public bool isPlayerBullet = true; // Merminin oyuncu tarafýndan mý yoksa düþman tarafýndan mý ateþlendiðini kontrol etmek için

    void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            if (isPlayerBullet && !health.isPlayer)
            {
                // Oyuncunun mermisi düþmana çarptý
                health.TakeDamage(damage);
            }
            else if (!isPlayerBullet && health.isPlayer)
            {
                // Düþmanýn mermisi oyuncuya çarptý
                health.TakeDamage(5);
            }
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
