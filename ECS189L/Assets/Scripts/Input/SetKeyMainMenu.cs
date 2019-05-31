using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetKeyMainMenu : MonoBehaviour
{
    Transform controls;
    Transform player;
    Transform buttonInit;

    Text buttonText;

    Event keyEvent;
    KeyCode newKey;
    string key;

    bool waitingForKey;

    public void Start()
    {
        waitingForKey = false;

        controls = this.transform;

        for (int i = 0; i < 4; i++)
        {
            player = controls.GetChild(i);

            for (int j = 0; j < player.childCount; j++)
            {
                buttonInit = player.GetChild(j);

                
                if (buttonInit.name == "AttackButton")
                {
                    key = "Attack"+(i+1).ToString();
                    buttonInit.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                }
                else if (buttonInit.name == "UpButton")
                {
                    key = "Up"+(i+1).ToString();
                    buttonInit.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                }
                else if (buttonInit.name == "DownButton")
                {
                    key = "Down"+(i+1).ToString();
                    buttonInit.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                }
                else if (buttonInit.name == "LeftButton")
                {
                    key = "Left"+(i+1).ToString();
                    buttonInit.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                }
                else if (buttonInit.name == "RightButton")
                {
                    key = "Right"+(i+1).ToString();
                    buttonInit.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                }
            }
        }
    }

    public void Update()
    {
        
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        
        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if(!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(Text text)
    {
        buttonText = text;
    }

    IEnumerator WaitForKey()
    {
        while(!keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();

        InputManager.IM.buttonKeys[keyName] = newKey;
        buttonText.text = InputManager.IM.buttonKeys[keyName].ToString();

        yield return null;

    }
}
