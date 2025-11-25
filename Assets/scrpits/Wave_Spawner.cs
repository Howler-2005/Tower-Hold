using UnityEngine;
using System.Collections;

public class Wave_Spawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public static Wave_Spawner instance;

    public float timeBetweenWaves = 20f;
    public float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }



}
