using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
  public string ChosenGame;

  public void PlayGame()
  {
   SharedInfo.CrossSceneInformation = EventSystem.current.currentSelectedGameObject.name;
   SceneManager.LoadScene(1);
  }

  void Update()
  {
    if (SharedInfo.PlayerScores.Count > 0)
    {
      this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
      this.gameObject.transform.GetChild(6).gameObject.SetActive(true);
      for(int i=0; i<=SharedInfo.PlayerScores.Count-1;i++)
      {
        int tempPlayer = i+1;
        this.gameObject.transform.GetChild(6).GetChild(i+2).gameObject.GetComponent<TextMeshProUGUI>().text = "Player"+tempPlayer.ToString()+": "+SharedInfo.PlayerScores[i+1];
      }
      SharedInfo.PlayerScores = new Dictionary<int, string>();
    }

  }
}
