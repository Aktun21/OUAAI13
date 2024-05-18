using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'i
    public Transform firePoint; // Merminin çýkýþ noktasý
    public float bulletSpeed = 10f; // Mermi hýzý
    public float shootRange = 5f; // Ateþ etme mesafesi
    public float fireRate = 1f; // Ateþ etme aralýðý
    private float nextFireTime = 0f; // Bir sonraki ateþ etme zamaný
    private Transform player; // Oyuncunun Transform bileþeni

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Oyuncuya yeteri kadar yaklaþtýðýnda ateþ et
        if (distanceToPlayer <= shootRange && Time.time >= nextFireTime)
        {
            AimAtPlayer();
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void AimAtPlayer()
    {
        // Oyuncunun pozisyonuna niþan al
        Vector3 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        // Mermiyi oluþtur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed; // Mermiyi ileri doðru fýrlat

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.isPlayerBullet = false; // Merminin düþman tarafýndan ateþlendiðini belirt
        }
    }

}
