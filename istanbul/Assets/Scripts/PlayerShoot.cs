using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Silahlarýn prefablarý
    public GameObject automaticGunPrefab; // Taramalý tüfek
    public GameObject shotgunPrefab; // Pompalý tüfek
    public GameObject sniperPrefab; // Keskin niþancý tüfeði

    // Ateþ noktasý
    public Transform firePoint;

    // Silahlarýn özellikleri
    private GameObject currentWeapon;
    private float fireRate;
    private int bulletCount;
    private float bulletSpeed;
    private float spread;
    private float reloadTime;

    private float nextFireTime = 0f; // Sonraki ateþ zamaný
    private bool isReloading = false; // Yeniden yükleme durumu
    void Start()
    {
        // Baþlangýçta 2. silahý seç
        SwitchWeapon(shotgunPrefab, 0.5f, 6, 8f, 5f, 3f);
    }
    void Update()
    {
        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha1)) // 1 tuþuna basýldýðýnda
        {
            SwitchWeapon(automaticGunPrefab, 0.2f, 1, 15f, 2f, 10f);
        }

        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha2)) // 2 tuþuna basýldýðýnda
        {
            SwitchWeapon(shotgunPrefab, 0.7f, 6, 8f, 4f, 1.5f);
        }

        if (!isReloading && Input.GetKeyDown(KeyCode.Alpha3)) // 3 tuþuna basýldýðýnda
        {
            SwitchWeapon(sniperPrefab, 1.5f, 1, 30f, 0f, 2f);
        }

        if (Input.GetButton("Fire1")) // Sol fare tuþuna basýlý tutulduðunda
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