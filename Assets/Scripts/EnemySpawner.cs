using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] waypoints;

    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemyPrefab;
        public float spawnInterval = 2;
        public int maxEnemies = 20;
    }

    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;


	void Start () {
        lastSpawnTime = Time.deltaTime;
	}
	
	void Update () {

        int currentWave = GameplayManager.Instance.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;

            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject) Instantiate(waves[currentWave].enemyPrefab[Random.Range(0, waves[currentWave].enemyPrefab.Length)]);
                newEnemy.GetComponent<EnemyMovement>().waypoints = waypoints;
                enemiesSpawned++;
            }
            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                GameplayManager.Instance.Wave++;
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
        else if (currentWave >= waves.Length)
        {
            GameplayManager.Instance.Invoke("GameOver", 0.4f);
        }

    }

     

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }


}
