using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int count = 1;
    public int ID;
    private bool Active = false;
    private const float DURATION = 0.4f;
    private const float OFFSET = 0.2f;
    private float ElapsedTime = 0.0f;
    private float health = 100.0f;

    private Vector2 shootingDirection = new Vector2(0, 1);

    bool skip;

    void Start()
    {
        skip = false;

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

    public void Shoot(Vector2 shootingDirection)
    {
        if(!this.Active)
        {
          this.gameObject.GetComponent<Animator>().SetBool("PlayerShoot", true);
          this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
          this.ElapsedTime = 0.0f;
          this.Active = true;
          PlayerShootCommand.Shoot(shootingDirection).Execute(this.gameObject);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        var dictionary = InputManager.IM.buttonKeys;
        int up = Input.GetKey(dictionary["Up"+this.ID.ToString()]) ? 1 : 0;
        int down = Input.GetKey(dictionary["Down"+this.ID.ToString()]) ? 1 : 0;
        int left = Input.GetKey(dictionary["Left"+this.ID.ToString()]) ? 1 : 0;
        int right = Input.GetKey(dictionary["Right"+this.ID.ToString()]) ? 1 : 0;
        int attack = Input.GetKey(dictionary["Attack"+this.ID.ToString()]) ? 1 : 0;

        StopMovement();
        this.gameObject.GetComponent<Animator>().SetBool("PlayerWalk", false);
        this.gameObject.GetComponent<Animator>().SetBool("PlayerShoot", false);
        this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", true);

        if (up + down + left + right > 2 || up + down + left + right == 0)
        {
            // Do nothing if more than 2 directions
            skip = true;
        }
        else
        {
            skip = false;
        }

        if (!skip)
        {
            if (up == 1)
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

            shootingDirection = new Vector2(right - left, up - down);
        }

        if (attack == 1)
        {
            Shoot(shootingDirection);
        }

        // Check if can shoot
        if (this.Active)
        {
            this.ElapsedTime += Time.deltaTime;
            if (this.ElapsedTime > OFFSET)
            {

                if (this.ElapsedTime > DURATION || !this.Active)
                {
                    this.Active = false;

                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.name == "Bullet(Clone)")
      {
        this.health -= 10;
        foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
         if(go.name == "PlayerUi(Clone)")
         {
           if (go.GetComponent<PlayerUi>().ID == this.ID)
           {
             go.transform.GetChild(1).GetComponent<HealthBar>().SetSize(this.health/100);
           }
         }
         if(this.health == 0)
         {
           Destroy(this.gameObject);
         }
       }
      }
    }

}
