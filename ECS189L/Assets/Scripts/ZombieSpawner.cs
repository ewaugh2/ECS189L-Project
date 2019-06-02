using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    private static ZombieSpawner instance = null;

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

    //Get instance (create if it doesn't already exist)
    public static ZombieSpawner getInstance()
    {
        if (instance == null)
        {
            instance = new ZombieSpawner();
        }

        return instance;
    }
}
