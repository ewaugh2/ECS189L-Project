using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCommand : ScriptableObject, IPlayerCommand
{
    private float Speed = 30;
    private Vector3 direction;

    static private float DIAGONAL_VALUE = 1.0f / Mathf.Sqrt(2);

    public void Init(Vector3 direction)
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
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(0, 1, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveDown()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(0, -1, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveRight()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(1, 0, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveLeft()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(-1, 0, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveUpRight()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(DIAGONAL_VALUE, DIAGONAL_VALUE, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveUpLeft()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(-DIAGONAL_VALUE, DIAGONAL_VALUE, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveDownRight()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(DIAGONAL_VALUE, -DIAGONAL_VALUE, 0));
        return data;
    }

    static public PlayerMovementCommand GetMoveDownLeft()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(-DIAGONAL_VALUE, -DIAGONAL_VALUE, 0));
        return data;
    }
    static public PlayerMovementCommand GetStandStill()
    {
        var data = ScriptableObject.CreateInstance<PlayerMovementCommand>();
        data.Init(new Vector3(0, 0, 0));
        return data;
    }

}
