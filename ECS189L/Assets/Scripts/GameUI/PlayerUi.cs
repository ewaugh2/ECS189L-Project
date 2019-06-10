using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUi : MonoBehaviour
{
  public static int count = 1;
  public int ID;

  void Start()
  {
      int auxID = count;
      this.ID = auxID;
      count += 1;
  }

  public void RestartPlayerUiCount()
  {
      count = 1;
  }
}
