using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private GameObject zombiePrefab;

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
        
    }

    //Set the prefab
    public void setPrefab(GameObject prefab)
    {
        zombiePrefab = prefab;
    }

    //Spawn a zombie
    public void spawnZombie()
    {
        var spawnpos = new Vector3(0, 0, 0);
        var zombie = (GameObject)Instantiate(zombiePrefab, spawnpos, Quaternion.identity); 
    }
}
