using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalSpawnManager : MonoBehaviour{
    public GameObject[] enemyPrefabs;
    public GameObject powerUpPrefab;
    public GameObject gameManager;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    int stealersSpawned;
    int speedersSpawned;

    // Start is called before the first frame update
    void Start(){
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update(){
        enemyCount = FindObjectsOfType<SurvivalEnemy>().Length + FindObjectsOfType<SurvivalStealEnemy>().Length;

        if(enemyCount == 0){
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            if(waveNumber % 2 == 1){
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            }
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn){
        stealersSpawned = 0;
        speedersSpawned = 0;
        for(int i = 0; i < enemiesToSpawn; ++i){
            selectedEnemySpawn();
        }
        gameManager.gameObject.GetComponent<SurvivalGameManager>().stage = waveNumber;
        gameManager.gameObject.GetComponent<SurvivalGameManager>().UpdateScore();
    }

    void selectedEnemySpawn(){
        
        if (waveNumber > 0 && waveNumber <= 5){
            int randomEnemy = 0;
            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
        else if(waveNumber > 5 && waveNumber <= 9){
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            if(stealersSpawned > 0 && randomEnemy == 1){
                randomEnemy = 0;
            }

            if(stealersSpawned < 1 && randomEnemy == 1){
                stealersSpawned++;
            }

            if(randomEnemy == 2) randomEnemy = 0;

            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
        else if(waveNumber > 9){
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            if(stealersSpawned > 0 && randomEnemy == 1){
                randomEnemy = 0;
            }

            if(stealersSpawned < 1 && randomEnemy == 1){
                stealersSpawned++;
            }

            if(speedersSpawned > 1 && randomEnemy == 2){
                randomEnemy = 0;
            }

            if(speedersSpawned < 2 && randomEnemy == 2){
                speedersSpawned++;
            }

            Instantiate(enemyPrefabs[randomEnemy], GenerateSpawnPosition(), enemyPrefabs[randomEnemy].transform.rotation);
        }
    } 

    private Vector3 GenerateSpawnPosition(){
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
    }
}
