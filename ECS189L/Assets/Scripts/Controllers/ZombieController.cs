using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
	[SerializeField] private GameObject zombieAgent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    	var zombie = zombieAgent.transform;

    	Debug.Log("Move to " + zombie.position);

        this.gameObject.transform.position = new Vector2(zombie.position.x, zombie.position.y);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, zombie.rotation.z);
    }
}
