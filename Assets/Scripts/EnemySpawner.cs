using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] waypoints;

    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
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
        // 1
        int currentWave = GameManager.instance.Wave;
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<EnemyMovement>().waypoints = waypoints;
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                GameManager.instance.Wave++;
                //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
        else
        {
            GameManager.instance.gameOver = true;
            //GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }

    }
}
