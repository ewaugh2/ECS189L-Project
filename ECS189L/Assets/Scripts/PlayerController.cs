using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private const float ZOMBIE_HIT_INTERVAL = 1f;
    private float sinceLastHit = 0f;

    public static int count = 1;
    public int ID;
    private bool Active = false;
    private const float DURATION = 0.4f;
    private const float OFFSET = 0.2f;
    private float ElapsedTime = 0.0f;
    private float health = 100.0f;

    private Vector2 shootingDirection = new Vector2(0, 1);

    bool skip;

    private int ammunition;

    void Start()
    {
        skip = false;
        ammunition = 100;
        SetAmmoUI();

        int auxID = count;
        this.ID = auxID;
        count += 1;
    }

    public void RestartPlayerCount()
    {
        count = 1;
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
            ammunition -= 1;
            SetAmmoUI();

            this.gameObject.GetComponent<Animator>().SetBool("PlayerShoot", true);
            this.gameObject.GetComponent<Animator>().SetBool("PlayerIdle", false);
            this.ElapsedTime = 0.0f;
            this.Active = true;
            PlayerShootCommand.Shoot(shootingDirection).Execute(this.gameObject);
        }
    }

    private void SetAmmoUI()
    {
        foreach(GameObject go in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if(go.name == "PlayerUi(Clone)")
            {
                if (go.GetComponent<PlayerUi>().ID == this.ID)
                {
                    for (int i = 0; i < go.transform.childCount; i++)
                    {
                        Transform child = go.transform.GetChild(i);
                        if (child.name == "Ammo")
                        {
                            child.gameObject.GetComponent<TextMeshProUGUI>().text = "x " + ammunition.ToString();
                        }
                    }
                }
            }
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

        // zombie timer
        sinceLastHit += Time.deltaTime;

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

        if (attack == 1 && ammunition > 0)
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

    private void OnCollisionStay2D(Collision2D collision)
    {
      OnCollisionEnter2D(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)" &&
            collision.gameObject.GetComponent<BulletController>().PlayerID != ID)
        {
           this.health -= 10f;
           foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
           {
             if(go.name == "PlayerUi(Clone)")
             {
               if (go.GetComponent<PlayerUi>().ID == this.ID)
               {
                 go.transform.GetChild(1).GetComponent<HealthBar>().SetSize(this.health/100);
               }
             }
           }
           Object bloodPrefab = Resources.Load("Prefabs/blood");
     			 var blood = (GameObject)Instantiate(bloodPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
     			 Destroy(blood, 1f);
         }
         if(collision.gameObject.name == "Zombie(Clone)" && sinceLastHit >= ZOMBIE_HIT_INTERVAL)
         {
           sinceLastHit = 0f;
            this.health -= 40f;
            foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
              if(go.name == "PlayerUi(Clone)")
              {
                if (go.GetComponent<PlayerUi>().ID == this.ID)
                {
                  go.transform.GetChild(1).GetComponent<HealthBar>().SetSize(this.health/100);
                }
              }
            }
            Object bloodPrefab = Resources.Load("Prefabs/blood");
      			var blood = (GameObject)Instantiate(bloodPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
      			Destroy(blood, 0.2f);
          }
      if(this.health <= 0)
      {
        foreach(GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
         if(go.name == "PlayerUi(Clone)")
         {
           if (go.GetComponent<PlayerUi>().ID == ID)
           {
             int newScore = int.Parse(go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text)-100;
             go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
             SharedInfo.PlayerScores[ID] = newScore.ToString();
           }
           if(collision.gameObject.name == "Bullet(Clone)" &&
               collision.gameObject.GetComponent<BulletController>().PlayerID != ID)
            {
             if (go.GetComponent<PlayerUi>().ID == collision.gameObject.GetComponent<BulletController>().PlayerID)
             {
               int newScore = int.Parse(go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text)+100;
               go.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
             }
            }
         }
       }
        this.gameObject.transform.GetChild(0).parent = GameObject.Find("PlayerUi(Clone)").transform;
        Destroy(this.gameObject);
      }
    }
}
