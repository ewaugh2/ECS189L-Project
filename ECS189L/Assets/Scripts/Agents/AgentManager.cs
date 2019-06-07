using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
	[SerializeField] private GameObject agentPrefab;

	private static AgentManager instance;

	public static AgentManager GetInstance()
	{
		return instance;
	}

	private Dictionary<GameObject, GameObject> agents;

	public GameObject AddAgent(GameObject owner)
	{
		Debug.Log("Added agent " + (agents.Count + 1));

		// Create agent
		var agent = Instantiate(agentPrefab) as GameObject;
		// Set agent position
		agent.transform.SetParent(this.gameObject.transform, false);
		//
		Debug.Log("Zombie created in " + agent.transform.position);
		Debug.Log("Zombie 2D in " + owner.transform.position);
		agent.transform.position = new Vector3(owner.transform.position.x, owner.transform.position.y, 150);
		Debug.Log("Zombie moved in " + agent.transform.position + "\n");
		// Save pair in dictionary
		agents[owner] = agent;
		return agent;
	}

	public bool RemoveAgent(GameObject owner)
	{
		return agents.Remove(owner);
	}

    // Awake is called before Start

    void Awake()
    {
        instance = this;
        agents = new Dictionary<GameObject, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
