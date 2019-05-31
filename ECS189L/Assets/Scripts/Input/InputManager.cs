using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager IM;

    public Dictionary<string, KeyCode> buttonKeys;

    void Awake()
    {
        if (IM == null)
        {
            DontDestroyOnLoad(gameObject);
            IM = this;
        }
        else if (IM != this)
        {
            Destroy(gameObject);
        }

        buttonKeys = new Dictionary<string, KeyCode>();

        buttonKeys["Up1"] = KeyCode.UpArrow;
        buttonKeys["Up2"] = KeyCode.W;
        buttonKeys["Up3"] = KeyCode.I;
        buttonKeys["Up4"] = KeyCode.T;


        buttonKeys["Down1"] = KeyCode.DownArrow;
        buttonKeys["Down2"] = KeyCode.S;
        buttonKeys["Down3"] = KeyCode.K;
        buttonKeys["Down4"] = KeyCode.G;

        buttonKeys["Left1"] = KeyCode.LeftArrow;
        buttonKeys["Left2"] = KeyCode.A;
        buttonKeys["Left3"] = KeyCode.J;
        buttonKeys["Left4"] = KeyCode.F;

        buttonKeys["Right1"] = KeyCode.RightArrow;
        buttonKeys["Right2"] = KeyCode.D;
        buttonKeys["Right3"] = KeyCode.L;
        buttonKeys["Right4"] = KeyCode.H;

        buttonKeys["Attack1"] = KeyCode.Space;
        buttonKeys["Attack2"] = KeyCode.Q;
        buttonKeys["Attack3"] = KeyCode.U;
        buttonKeys["Attack4"] = KeyCode.R;
    }
}
