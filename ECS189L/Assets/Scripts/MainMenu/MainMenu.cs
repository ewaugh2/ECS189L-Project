using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
  public string ChosenGame;

  public void PlayGame()
  {
   SceneManager.LoadScene(1);
   this.ChosenGame = EventSystem.current.currentSelectedGameObject.name;
  }
}
