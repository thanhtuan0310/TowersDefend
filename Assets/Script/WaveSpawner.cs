using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    
    public Transform spawnPoint;

    public ManagerGames gameManager;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    public Text waveCount;
   
    void Update()
    {
     if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length && PlayerStarts.Lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
            Debug.Log("You Won");

        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCount.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        
        PlayerStarts.Rounds++;

        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate); 
        }
        waveIndex++;

        
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        
    }
}
