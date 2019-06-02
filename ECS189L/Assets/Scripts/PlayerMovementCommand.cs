using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCommand : ScriptableObject, IPlayerCommand
{
    private float Speed = 5;
    private Vector3 direction;

    static private float DIAGONAL_VALUE = 1.0f / Mathf.Sqrt(2);

    private PlayerMovementCommand(Vector3 direction)
    {
        this.direction = direction;
    }

    public bool Execute(GameObject gameObject)
    {
        var rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody != null)
        {
            rigidBody.velocity = new Vector3(Speed * direction.x, Speed * direction.y, Speed * direction.z);
        }
        return true;
    }

    static public PlayerMovementCommand GetMoveUp()
    {
        return new PlayerMovementCommand(new Vector3(0, 1, 0));
    }

    static public PlayerMovementCommand GetMoveDown()
    {
        return new PlayerMovementCommand(new Vector3(0, -1, 0));
    }

    static public PlayerMovementCommand GetMoveRight()
    {
        return new PlayerMovementCommand(new Vector3(1, 0, 0));
    }

    static public PlayerMovementCommand GetMoveLeft()
    {
        return new PlayerMovementCommand(new Vector3(-1, 0, 0));
    }

    static public PlayerMovementCommand GetMoveUpRight()
    {
        return new PlayerMovementCommand(new Vector3(DIAGONAL_VALUE, DIAGONAL_VALUE, 0));
    }

    static public PlayerMovementCommand GetMoveUpLeft()
    {
        return new PlayerMovementCommand(new Vector3(DIAGONAL_VALUE, -DIAGONAL_VALUE, 0));
    }

    static public PlayerMovementCommand GetMoveDownRight()
    {
        return new PlayerMovementCommand(new Vector3(-DIAGONAL_VALUE, DIAGONAL_VALUE, 0));
    }

    static public PlayerMovementCommand GetMoveDownLeft()
    {
        return new PlayerMovementCommand(new Vector3(-DIAGONAL_VALUE, -DIAGONAL_VALUE, 0));
    }

}