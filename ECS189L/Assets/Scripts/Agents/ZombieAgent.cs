using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var players = GameManager.GetIstance().GetAlivePlayers();

        // Current position
        var position = this.gameObject.transform.position;

        GameObject closest = null;
        foreach(var player in players)
        {
        	if(closest == null || Vector.distance(position, player.transform.position) < Vector.distance(position, player.transform.position))
        	{
        		closest = player;
        	}
        }

        // Set move to location
        agent.SetDestination(new Vector3(player.transform.position.x, position.y, player.transform.position.y));
    }
}
