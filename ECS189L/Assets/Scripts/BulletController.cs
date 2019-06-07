using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletController : MonoBehaviour
{

  public int PlayerID;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.name == "Player(Clone)" && 
        PlayerID != collision.gameObject.GetComponent<PlayerController>().ID)
    {
      foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
      {
        if(go.name == "PlayerUi(Clone)")
        {
          if (go.GetComponent<PlayerUi>().ID == PlayerID)
          {
            int newScore = int.Parse(go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text)+10;
            go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
          }
        }
      }
    }
    Destroy(this.gameObject);
  }
}
