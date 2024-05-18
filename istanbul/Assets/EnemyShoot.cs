using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'i
    public Transform firePoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 10f; // Mermi h�z�
    public float shootRange = 5f; // Ate� etme mesafesi
    public float fireRate = 1f; // Ate� etme aral���
    private float nextFireTime = 0f; // Bir sonraki ate� etme zaman�
    private Transform player; // Oyuncunun Transform bile�eni

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Oyuncuya yeteri kadar yakla�t���nda ate� et
        if (distanceToPlayer <= shootRange && Time.time >= nextFireTime)
        {
            AimAtPlayer();
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void AimAtPlayer()
    {
        // Oyuncunun pozisyonuna ni�an al
        Vector3 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        // Mermiyi olu�tur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed; // Mermiyi ileri do�ru f�rlat

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.isPlayerBullet = false; // Merminin d��man taraf�ndan ate�lendi�ini belirt
        }
    }

}
