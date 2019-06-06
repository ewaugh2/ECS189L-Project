using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int count = 1;
    public int ID;

    void Start()
    {
        int auxID = count;
        this.ID = auxID;
        count += 1;
    }

    public void MoveUp()
    {
        PlayerMovementCommand.GetMoveUp().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void MoveDown()
    {
        PlayerMovementCommand.GetMoveDown().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
    }
    public void MoveLeft()
    {
        PlayerMovementCommand.GetMoveLeft().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
    }
    public void MoveRight()
    {
        PlayerMovementCommand.GetMoveRight().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
    }
    public void MoveUpRight()
    {
        PlayerMovementCommand.GetMoveUpRight().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 315);
    }
    public void MoveUpLeft()
    {
        PlayerMovementCommand.GetMoveUpLeft().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
    }
    public void MoveDownRight()
    {
        PlayerMovementCommand.GetMoveDownRight().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 225);
    }
    public void MoveDownLeft()
    {
        PlayerMovementCommand.GetMoveDownLeft().Execute(this.gameObject);
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 135);
    }
    public void StopMovement()
    {
        PlayerMovementCommand.GetStandStill().Execute(this.gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var dictionary = InputManager.IM.buttonKeys;
        int up = Input.GetKey(dictionary["Up"+this.ID.ToString()]) ? 1 : 0;
        int down = Input.GetKey(dictionary["Down"+this.ID.ToString()]) ? 1 : 0;
        int left = Input.GetKey(dictionary["Left"+this.ID.ToString()]) ? 1 : 0;
        int right = Input.GetKey(dictionary["Right"+this.ID.ToString()]) ? 1 : 0;

        StopMovement();
        this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", false);
        this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", true);

        if (up + down + left + right > 2)
        {
            // Do nothing if more than 2 directions
        }
        else if (up == 1)
        {
          this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", true);
          this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
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
          this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", true);
          this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
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
            this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", true);
            this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
            MoveLeft();
        }
        else if (right == 1)
        {
            this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", true);
            this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
            MoveRight();
        }
    }

}
