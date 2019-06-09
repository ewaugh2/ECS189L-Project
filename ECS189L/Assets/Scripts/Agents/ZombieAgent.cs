using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAgent : MonoBehaviour
{

	private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Choose player to attack
        var players = GameManager.getInstance().GetAlivePlayers();

        // Current position
        var position = this.gameObject.transform.position;

        GameObject closest = null;
        foreach(var player in players)
        {
        	if(closest == null || Vector3.Distance(position, player.transform.position) < Vector3.Distance(position, closest.transform.position))
        	{
        		closest = player;
        	}
        }

        // Set move to location
        var destination = new Vector3(0, 0, 0);
        if (closest != null)
        {
            destination = new Vector3(closest.transform.position.x, closest.transform.position.y, position.z);
        }

        agent.SetDestination(destination);
        // Debug.Log("Zombie location: " + position + "\nPlayer location: " + closest.transform.position + "\nDestination: " + destination + "\n");
    }
}
