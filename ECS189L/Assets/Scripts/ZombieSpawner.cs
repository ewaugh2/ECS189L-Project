using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    const float SPAWN_INTERVAL = 10.0f;
    const float SPAWN_INCREASE_INTERVAL = 60.0f;
    const int SPAWN_INCREASE_AMOUNT = 1;

    private GameObject zombiePrefab;
    float timeToNextSpawn = SPAWN_INTERVAL;
    float timeToSpawnIncrease = SPAWN_INCREASE_INTERVAL;
    int numZombiesToSpawn = 1;
    int numZombies = 0;

    private ZombieSpawner()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnUpdate();
    }

    //Update spawn timers, spawn if timers are up
    private void spawnUpdate()
    {
        timeToNextSpawn -= Time.deltaTime;
        timeToSpawnIncrease -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            timeToNextSpawn = SPAWN_INTERVAL;

            for (int i = 0; i < numZombiesToSpawn; i++)
            {
                spawnZombie();
            }
        }

        if (timeToSpawnIncrease <= 0)
        {
            timeToSpawnIncrease = SPAWN_INCREASE_INTERVAL;

            numZombiesToSpawn += SPAWN_INCREASE_AMOUNT;
        }
    }

    //Set the prefab
    public void setPrefab(GameObject prefab)
    {
        zombiePrefab = prefab;
    }

    //Spawn a zombie
    private void spawnZombie()
    {
        var pos = this.gameObject.transform.position;
        var zombie = (GameObject)Instantiate(zombiePrefab, pos, Quaternion.identity);
    }
}