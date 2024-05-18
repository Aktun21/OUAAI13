using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // Ekran�n d�rt k��esindeki spawn noktalar�
    public float spawnInterval = 3f; // Spawn aral���

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktas� se�
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // D��man� spawnla
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
