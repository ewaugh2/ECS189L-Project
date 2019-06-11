using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieController : MonoBehaviour
{
	[SerializeField] private GameObject zombie3D;

    // Start is called before the first frame update
    void Start()
    {
        zombie3D = AgentManager.GetInstance().AddAgent(this.gameObject);
    }

    // Method to set the assigned agent
    public void SetAgent(GameObject newAgent)
    {
        this.zombie3D = newAgent;
    }

    // Update is called once per frame
    void Update()
    {
    	var zombie = zombie3D.transform;

    	// Copy location
        this.gameObject.transform.position = new Vector3(zombie.position.x, zombie.position.y, -0.5f);
        // Copy rotation
        this.gameObject.transform.rotation = zombie.transform.rotation;
        this.gameObject.transform.Rotate(90, 0, 0);
    }

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if(collision.gameObject.name == "Bullet(Clone)")
			{
				foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
				{
				 if(go.name == "PlayerUi(Clone)")
				 {
					 if (go.GetComponent<PlayerUi>().ID == collision.gameObject.GetComponent<BulletController>().PlayerID)
					 {
						 int newScore = int.Parse(go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text)+5;
						 go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
					 }
				 }
			 }
				AgentManager.GetInstance().KillZombie(this.gameObject);
				Object bloodPrefab = Resources.Load("Prefabs/blood2");
				var blood = (GameObject)Instantiate(bloodPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
				Destroy(blood, 5f);
				Destroy(this.gameObject);

			}
		}
}
