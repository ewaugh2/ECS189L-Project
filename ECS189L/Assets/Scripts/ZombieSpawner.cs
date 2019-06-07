using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private GameObject zombiePrefab;
    float timeToNextSpawn = 10.0f;
    float timeToSpawnIncrease = 60.0f;
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
        timeToNextSpawn -= Time.deltaTime;
        timeToSpawnIncrease -= Time.deltaTime;

        if(timeToNextSpawn <= 0)
        {
            timeToNextSpawn = 10.0f;

            for (int i = 0; i < numZombiesToSpawn; i++)
            {
                spawnZombie();
            }
        }

        if(timeToSpawnIncrease <= 0)
        {
            timeToSpawnIncrease = 60.0f;

            numZombiesToSpawn += 1;

            Debug.Log(numZombies);
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
        pos.x += 20;
        var zombie = (GameObject)Instantiate(zombiePrefab, pos, Quaternion.identity);
        numZombies++;
    }
}
