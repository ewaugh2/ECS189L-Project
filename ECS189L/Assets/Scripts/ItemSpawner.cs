using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : ScriptableObject
{
    private static ItemSpawner instance = null;

    //Item prefabs
    private GameObject ammoPickupPrefab;
    private GameObject healthPickupPrefab;

    //Item drop rates
    private const float AMMO_DROP_RATE = 0.10f;
    private const float HEALTH_DROP_RATE = 0.10f;

    private ItemSpawner()
    {

    }

    //Get the instance
    public static ItemSpawner getInstance()
    {
        if(instance == null)
        {
            instance = new ItemSpawner();
        }

        return instance;
    }

    //Set the prefabs
    public void setPrefabs(GameObject ammoPrefab, GameObject healthPrefab)
    {
        ammoPickupPrefab = ammoPrefab;
        healthPickupPrefab = healthPrefab;
    }

    //Spawn an item at pos
    public void spawnItem(Vector3 pos)
    {
        float itemSpawn = Random.Range(0, 1);

        //10% chance of spawning ammo, 10% chance of spawning health. Spawn only one item at a time.
        if(itemSpawn <= AMMO_DROP_RATE)
        {
            //Spawn ammo
            spawnAmmo(pos);
        }
        else if(itemSpawn <= AMMO_DROP_RATE + HEALTH_DROP_RATE)
        {
            spawnHealth(pos);
        }
    }

    //Spawn ammo pickup at pos
    private void spawnAmmo(Vector3 pos)
    {
        var ammoPickup = (GameObject)Instantiate(ammoPickupPrefab, pos, Quaternion.identity);
    }

    //Spawn health pickup at pos
    private void spawnHealth(Vector3 pos)
    {
        var healthPickup = (GameObject)Instantiate(healthPickupPrefab, pos, Quaternion.identity);
    }
}
