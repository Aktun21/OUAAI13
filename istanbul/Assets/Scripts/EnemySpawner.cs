using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // Ekranýn dört köþesindeki spawn noktalarý
    public float spawnInterval = 3f; // Spawn aralýðý

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktasý seç
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        // Düþmaný spawnla
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
