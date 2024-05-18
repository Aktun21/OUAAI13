using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'i
    public Transform firePoint; // Merminin çýkýþ noktasý
    public float bulletSpeed = 10f; // Mermi hýzý
    
    void Update()
    {
        // Sol fare tuþuna basýldýðýnda ateþ et
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }

    void Shoot()
    {

     
        // Mermiyi oluþtur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed; // Mermiyi ileri doðru fýrlat
    }
}
