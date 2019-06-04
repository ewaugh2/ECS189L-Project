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

    private static Dictionary<Transform, Text> transformTextDict = new Dictionary<Transform, Text>();
    private static Dictionary<Transform, string> transformKeyDict = new Dictionary<Transform, string>();

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
                    transformKeyDict[buttonInit] = "Attack"+(i+1).ToString();
                    transformTextDict[buttonInit] = buttonInit.GetComponentInChildren<Text>();
                    
                    transformTextDict[buttonInit].text = InputManager.IM.buttonKeys[transformKeyDict[buttonInit]].ToString();
                }
                else if (buttonInit.name == "UpButton")
                {
                    transformKeyDict[buttonInit] = "Up"+(i+1).ToString();
                    transformTextDict[buttonInit] = buttonInit.GetComponentInChildren<Text>();
                    
                    transformTextDict[buttonInit].text = InputManager.IM.buttonKeys[transformKeyDict[buttonInit]].ToString();
                }
                else if (buttonInit.name == "DownButton")
                {
                    transformKeyDict[buttonInit] = "Down"+(i+1).ToString();
                    transformTextDict[buttonInit] = buttonInit.GetComponentInChildren<Text>();
                    
                    transformTextDict[buttonInit].text = InputManager.IM.buttonKeys[transformKeyDict[buttonInit]].ToString();
                }
                else if (buttonInit.name == "LeftButton")
                {
                    transformKeyDict[buttonInit] = "Left"+(i+1).ToString();
                    transformTextDict[buttonInit] = buttonInit.GetComponentInChildren<Text>();
                    
                    transformTextDict[buttonInit].text = InputManager.IM.buttonKeys[transformKeyDict[buttonInit]].ToString();
                }
                else if (buttonInit.name == "RightButton")
                {
                    transformKeyDict[buttonInit] = "Right"+(i+1).ToString();
                    transformTextDict[buttonInit] = buttonInit.GetComponentInChildren<Text>();
                    
                    transformTextDict[buttonInit].text = InputManager.IM.buttonKeys[transformKeyDict[buttonInit]].ToString();
                }
                else
                {
                    continue;
                }
                Transform transformCopy = buttonInit;

                buttonInit.GetComponent<Button>().onClick.AddListener(() => SendText(transformTextDict[transformCopy]));
                buttonInit.GetComponent<Button>().onClick.AddListener(() => StartAssignment(transformKeyDict[transformCopy]));
            }
        }
    }

    public void Update()
    {
        
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
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
