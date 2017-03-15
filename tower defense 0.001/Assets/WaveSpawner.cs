using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public float timeBetweenWaves;
    public float countdown;
    private int WaveNumer;
    public Transform SpawnPoint;
    public float DistanceTimeBetweenSpawn;
    private void Update()
    {
        if (countdown <= 0) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave() {
        WaveNumer++;


        for (int i = 0; i < WaveNumer; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(DistanceTimeBetweenSpawn);
        }

        
    }
    void SpawnEnemy() {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
            
    }
}
