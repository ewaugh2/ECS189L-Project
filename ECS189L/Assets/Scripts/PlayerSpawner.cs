using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject playerPrefab;

    public PlayerSpawner()
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
        playerPrefab = prefab;
    }

    //Spawn the player
    public void spawnPlayer()
    {
        var map = GameObject.Find("Map");
        var player = (GameObject)Instantiate(playerPrefab, map.transform.localPosition + new Vector3(100,100,0), Quaternion.identity);
        player.transform.parent = GameObject.Find("Canvas").transform;
    }
}
