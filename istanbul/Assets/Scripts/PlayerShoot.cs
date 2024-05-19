using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Silahlar�n prefablar�
    public GameObject automaticGunPrefab; // Taramal� t�fek
    public GameObject shotgunPrefab; // Pompal� t�fek
    public GameObject sniperPrefab; // Keskin ni�anc� t�fe�i

    // Ate� noktas�
    public Transform firePoint;

    // Silahlar�n �zellikleri
    private GameObject currentWeapon;
    private float fireRate;
    private int bulletCount;
    private float bulletSpeed;
    private float spread;
    private float reloadTime;

    private float nextFireTime = 0f; // Sonraki ate� zaman�
    private bool isReloading = false; // Yeniden y�kleme durumu
    void Start()
    {
        // Ba�lang��ta 2. silah� se�
        SwitchWeapon(shotgunPrefab, 0.5f, 6, 8f, 5f, 3f);
    }
    void Update()
    {
        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha1)) // 1 tu�una bas�ld���nda
        {
            SwitchWeapon(automaticGunPrefab, 0.2f, 1, 15f, 2f, 10f);
        }

        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha2)) // 2 tu�una bas�ld���nda
        {
            SwitchWeapon(shotgunPrefab, 0.7f, 6, 8f, 4f, 1.5f);
        }

        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha3)) // 3 tu�una bas�ld���nda
        {
            SwitchWeapon(sniperPrefab, 1.5f, 1, 30f, 0f, 2f);
        }

        if (Input.GetButton("Fire1")) // Sol fare tu�una bas�l� tutuldu�unda
        {
            Shoot();
        }
    }

    void SwitchWeapon(GameObject weaponPrefab, float rate, int count, float speed, float spreadAmount, float reload)
    {
        currentWeapon = weaponPrefab;
        fireRate = rate;
        bulletCount = count;
        bulletSpeed = speed;
        spread = spreadAmount;
        reloadTime = reload;
    }

    void Shoot()
    {
        if (currentWeapon != null && Time.time >= nextFireTime)
        {
            for (int i = 0; i < bulletCount; i++)
            {
                Vector2 direction = GetShotDirection();
                GameObject bullet = Instantiate(currentWeapon, firePoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }

            nextFireTime = Time.time + fireRate;
        }
    }

    Vector2 GetShotDirection()
    {
        Vector2 direction = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)firePoint.position;
        direction += Random.insideUnitCircle * spread;
        direction.Normalize();
        return direction;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
}