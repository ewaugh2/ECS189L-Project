using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootCommand : ScriptableObject, IPlayerCommand
{
    private GameObject Player;
    private BoxCollider2D ColliderBox;
    Vector3 spawnPosition;
    private const float Speed = 150.0f;
    private Vector2 shootingDirection;

    // public GameObject bulletPrefab;

    public bool Execute(GameObject gameObject)
    {
        this.Player = gameObject;
        Object bulletPrefab = Resources.Load("Prefabs/Bullet");

        spawnPosition = new Vector3(10 * shootingDirection.x,
                                    10 * shootingDirection.y,
                                    0);

        var projectile = (GameObject) Instantiate(bulletPrefab, Player.transform.position + spawnPosition, Player.transform.rotation);
        var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();

        projectileRigidBody.velocity = new Vector2(Speed * shootingDirection.x,
                                                    Speed * shootingDirection.y);

        Destroy(projectile, 2f);

        return true;
    }

    static public PlayerShootCommand Shoot(Vector2 direction)
    {
        var data = ScriptableObject.CreateInstance<PlayerShootCommand>();
        data.shootingDirection = direction;
        return data;
    }
}
