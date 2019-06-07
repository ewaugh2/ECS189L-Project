using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletController : MonoBehaviour
{

  public int PlayerID;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(this.gameObject);
  }
}
