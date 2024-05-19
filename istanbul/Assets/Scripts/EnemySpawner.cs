using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Birinci tür düþman prefabý
    public GameObject enemyType2Prefab; // Ýkinci tür düþman prefabý
    public Transform[] spawnPoints; // Düþmanlarýn spawnlandýðý noktalar
    public Transform[] spawnPointsType2; // Ýkinci tür düþmanlarýn spawnlandýðý noktalar

    public float spawnRate = 2f; // Normal spawn hýzý
    public float fastSpawnRate = 1f; // Hýzlý spawn hýzý
    private float nextSpawnTime = 0f;
    private bool isFastSpawn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFastSpawn = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFastSpawn = false;
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + (isFastSpawn ? fastSpawnRate : spawnRate);
        }
    }

    void SpawnEnemy()
    {
        if (isFastSpawn)
        {
            // Ýkinci tür düþmaný rastgele bir spawn noktasýnda spawnla
            int spawnIndex = Random.Range(0, spawnPointsType2.Length);
            Instantiate(enemyType2Prefab, spawnPointsType2[spawnIndex].position, spawnPointsType2[spawnIndex].rotation);
        }
        else
        {
            // Birinci tür düþmaný rastgele bir spawn noktasýnda spawnla
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}
