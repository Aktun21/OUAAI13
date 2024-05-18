using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Düþmanýn hareket hýzý
    private Transform player; // Oyuncunun Transform bileþeni

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Oyuncuya doðru olan yön
        Vector3 direction = (player.position - transform.position).normalized;

        // Düþmaný oyuncuya doðru hareket ettir
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
