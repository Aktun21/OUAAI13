using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Birinci t�r d��man prefab�
    public GameObject enemyType2Prefab; // �kinci t�r d��man prefab�
    public Transform[] spawnPoints; // D��manlar�n spawnland��� noktalar
    public Transform[] spawnPointsType2; // �kinci t�r d��manlar�n spawnland��� noktalar

    public float spawnRate = 2f; // Normal spawn h�z�
    public float fastSpawnRate = 1f; // H�zl� spawn h�z�
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
            // �kinci t�r d��man� rastgele bir spawn noktas�nda spawnla
            int spawnIndex = Random.Range(0, spawnPointsType2.Length);
            Instantiate(enemyType2Prefab, spawnPointsType2[spawnIndex].position, spawnPointsType2[spawnIndex].rotation);
        }
        else
        {
            // Birinci t�r d��man� rastgele bir spawn noktas�nda spawnla
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}
