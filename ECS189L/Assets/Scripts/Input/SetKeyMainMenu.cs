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

    GameObject button;
    GameObject child;
    string buttonText;

    Event keyEvent;
    KeyCode newKey;
    string key;

    bool waitingForKey;

    List<string> buttonList;

    public void Start()
    {
        waitingForKey = false;

        buttonList = new List<string>();
        buttonList.Add("UpButton");
        buttonList.Add("DownButton");
        buttonList.Add("LeftButton");
        buttonList.Add("RightButton");
        buttonList.Add("AttackButton");

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
        

        // if (keyEvent.isKey && waitingForKey)
        // {
        //     newKey = keyEvent.KeyCode;
        //     waitingForKey = false;
        // }
    }

    public void Update()
    {
        button = EventSystem.current.currentSelectedGameObject;

        if (button.name != "Settings")
        {
            waitingForKey = false;
            OnGUI();
        }
    }

    public void OnGUI()
    {
        if (button != null)
        {
            if (buttonList.Contains(button.name) && !waitingForKey)
            {
                waitingForKey = true;
                // Debug.Log(button.name);
            }
            else
            {
                waitingForKey = false;
            }
        }

        if (waitingForKey)
        {
            keyEvent = Event.current;
            
            if (keyEvent != null)
            {
                if (keyEvent.isKey)
                {
                    key = button.name.Substring(0, button.name.Length - 6) + button.transform.parent.name.Substring(6, 1);
                    newKey = keyEvent.keyCode;

                    InputManager.IM.buttonKeys[key] = newKey;
                    button.GetComponentInChildren<Text>().text = InputManager.IM.buttonKeys[key].ToString();
                    // waitingForKey = false;

                    // Debug.Log(key);
                    // Debug.Log(newKey);
                    // Debug.Log(" ");
                }
            }
        }
        
            
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(string text)
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

        key = button.GetComponentInChildren<Text>().text;
        var number = button.transform.parent.name;
        Debug.Log(key + number.GetType() + number);

        // switch (keyName)
        // {
        //     case "UpButton":
        //         InputManager.IM.buttonKeys[button.GetComponentInChildren<Text>().text];
        //     default:
        // }

        yield return null;
    }
}
