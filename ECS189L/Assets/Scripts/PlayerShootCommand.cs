using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootCommand : ScriptableObject, IPlayerCommand
{
    private bool Active;
    private const float DURATION = 0.4f;
    private const float OFFSET = 0.2f;
    private float ElapsedTime;
    private GameObject Player;
    private BoxCollider2D ColliderBox;
    Vector3 spawnPosition;
    private const float Speed = 65.0f;
    private Vector2 shootingDirection;

    // public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ElapsedTime = 0.0f;
        Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime > OFFSET && ElapsedTime > DURATION)
            {
                Active = false;
            }
        }
        // DO animation
        // this.Player.GetComponent<Animator>().SetBool("Attack", this.Active);
    }

    public bool Execute(GameObject gameObject)
    {
        if(!this.Active)
        {
            this.ElapsedTime = 0.0f;
            this.Active = true;

            this.Player = gameObject;
            Object bulletPrefab = Resources.Load("Prefabs/Bullet");

            // Set position

            // if (!Player.GetComponent<SpriteRenderer>().flipX) {
            //   spawnPosition = new Vector3(1,0,0);
            // }
            // else
            // {
            //   spawnPosition = new Vector3(-1,0,0);
            // }

            spawnPosition = new Vector3(10 * shootingDirection.x,
                                        10 * shootingDirection.y, 
                                        0);

            var projectile = (GameObject) Instantiate(bulletPrefab, Player.transform.position + spawnPosition, Player.transform.rotation);
            var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();

            // Set direction

            // if (!Player.GetComponent<SpriteRenderer>().flipX) {
            //   projectileRigidBody.velocity = new Vector2(20, projectileRigidBody.velocity.y);
            // }
            // else
            // {
            //   projectileRigidBody.velocity = new Vector2(-20, projectileRigidBody.velocity.y);
            // }

            projectileRigidBody.velocity = new Vector2(Speed * shootingDirection.x, 
                                                        Speed * shootingDirection.y);

            Destroy(projectile, 3.0f);

            // Set colider box
            // this.ColliderBox = this.Player.transform.Find("Motivator").GetComponent<BoxCollider2D>();

            return true;
        }

        return false;
    }

    static public PlayerShootCommand Shoot(Vector2 direction)
    {
        var data = ScriptableObject.CreateInstance<PlayerShootCommand>();
        data.shootingDirection = direction;
        return data;
    }
}
