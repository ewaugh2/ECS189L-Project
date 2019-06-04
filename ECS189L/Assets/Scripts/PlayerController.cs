using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int state = 0;

    public void MoveUp()
    {
        PlayerMovementCommand.GetMoveUp().Execute(this.gameObject);
    }
    public void MoveDown()
    {
        PlayerMovementCommand.GetMoveDown().Execute(this.gameObject);
    }
    public void MoveLeft()
    {
        PlayerMovementCommand.GetMoveLeft().Execute(this.gameObject);
    }
    public void MoveRight()
    {
        PlayerMovementCommand.GetMoveRight().Execute(this.gameObject);
    }
    public void MoveUpRight()
    {
        PlayerMovementCommand.GetMoveUpRight().Execute(this.gameObject);
    }
    public void MoveUpLeft()
    {
        PlayerMovementCommand.GetMoveUpLeft().Execute(this.gameObject);
    }
    public void MoveDownRight()
    {
        PlayerMovementCommand.GetMoveDownRight().Execute(this.gameObject);
    }
    public void MoveDownLeft()
    {
        PlayerMovementCommand.GetMoveDownLeft().Execute(this.gameObject);
    }
    public void StopMovement()
    {
        PlayerMovementCommand.GetStandStill().Execute(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Assuming it's player 1
        var dictionary = InputManager.IM.buttonKeys;
        int up = Input.GetKey(dictionary["Up1"]) ? 1 : 0;
        int down = Input.GetKey(dictionary["Down1"]) ? 1 : 0;
        int left = Input.GetKey(dictionary["Left1"]) ? 1 : 0;
        int right = Input.GetKey(dictionary["Right1"]) ? 1 : 0;

        StopMovement();

        if (up + down + left + right > 2)
        {
            // Do nothing if more than 2 directions
        }
        else if (up == 1)
        {
            if (left == 1)
            {
                MoveUpLeft();
            }
            else if (right == 1)
            {
                MoveUpRight();
            }
            else
            {
                MoveUp();
            }
        }
        else if (down == 1)
        {
            if (left == 1)
            {
                MoveDownLeft(); 
            }
            else if (right == 1)
            {
                MoveDownRight();
            }
            else
            {
                MoveDown();
            }
        }
        else if (left == 1)
        {
            MoveLeft();
        }
        else if (right == 1)
        {
            MoveRight();
        }
    }

}
