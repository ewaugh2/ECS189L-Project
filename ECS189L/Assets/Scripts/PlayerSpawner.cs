using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject playerPrefab;
    private GameObject playerUiPrefab;
    public Collider2D[] colliders;
    public float radius = 50;

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

    bool preventSpawnOverlap(Vector3 spawnPos, GameObject map)
    {
      colliders = Physics2D.OverlapCircleAll(map.transform.localPosition, radius);
      for(int i = 0; i < colliders.Length; i++)
      {
        Vector3 centerPoint = colliders[i].bounds.center;
        float width = colliders[i].bounds.extents.x;
        float height = colliders[i].bounds.extents.y;
        float leftExtent = centerPoint.x - width;
        float rightExtent = centerPoint.x + width;
        float lowerExtent = centerPoint.y - height;
        float upperExtent = centerPoint.y + height;
        if(spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
        {
          if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
          {
            return false;
          }
        }
      }
      return true;
    }

    //Spawn the player
    public void spawnPlayer()
    {
        var map = GameObject.Find("Map");
        bool canSpawnHere = false;
        Vector3 spawnPos = new Vector3(0,0,0);
        int safetyNet = 0;

        while (!canSpawnHere)
        {
          float spawnPosX = Random.Range(-210f, 210f);
          float spawnPosY = Random.Range(-185f, 185f);
          spawnPos = map.transform.localPosition + new Vector3(spawnPosX,spawnPosY,0);
          canSpawnHere = preventSpawnOverlap(spawnPos, map);
          if(canSpawnHere)
          {
            break;
          }
          if(safetyNet > 50)
          {
            spawnPos = map.transform.localPosition + new Vector3(100,100,0);
            break;
          }
          safetyNet++;
        }
        var player = (GameObject)Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        var playerUi = (GameObject)Instantiate(playerUiPrefab, map.transform.localPosition + new Vector3(-140,20,0), Quaternion.identity);
        player.transform.parent = GameObject.Find("Map").transform;
        playerUi.transform.parent = GameObject.Find("Canvas").transform;
    }
}
