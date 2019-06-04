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
   SharedInfo.CrossSceneInformation = EventSystem.current.currentSelectedGameObject.name;
   SceneManager.LoadScene(1);
  }
}
