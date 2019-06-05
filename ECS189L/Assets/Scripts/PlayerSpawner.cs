using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject playerPrefab;
    private GameObject playerUiPrefab;

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
    public void setPrefab(GameObject prefab, GameObject gameUi)
    {
        playerPrefab = prefab;
        playerUiPrefab = gameUi;
    }

    //Spawn the player
    public void spawnPlayer()
    {
        var map = GameObject.Find("Map");
        var canvas = GameObject.Find("Canvas");
        var player = (GameObject)Instantiate(playerPrefab, map.transform.localPosition + new Vector3(20,20,0), Quaternion.identity);
        var playerUi = (GameObject)Instantiate(playerUiPrefab, canvas.transform.localPosition - new Vector3(580,-20,0), Quaternion.identity);
        player.transform.parent = GameObject.Find("Map").transform;
        playerUi.transform.parent = GameObject.Find("Canvas").transform;
    }
}
