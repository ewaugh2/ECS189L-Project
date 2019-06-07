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
    private void spawnZombie()
    {
        var pos = this.gameObject.transform.position;
        pos.x += 20;
        var zombie = (GameObject)Instantiate(zombiePrefab, pos, Quaternion.identity);
    }
}
