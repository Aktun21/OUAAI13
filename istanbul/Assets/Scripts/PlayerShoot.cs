using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'i
    public Transform firePoint; // Merminin ��k�� noktas�
    public float bulletSpeed = 10f; // Mermi h�z�
    
    void Update()
    {
        // Sol fare tu�una bas�ld���nda ate� et
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }

    void Shoot()
    {

     
        // Mermiyi olu�tur
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed; // Mermiyi ileri do�ru f�rlat
    }
}
