using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // D��man�n hareket h�z�
    private Transform player; // Oyuncunun Transform bile�eni

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Oyuncuya do�ru olan y�n
        Vector3 direction = (player.position - transform.position).normalized;

        // D��man� oyuncuya do�ru hareket ettir
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
