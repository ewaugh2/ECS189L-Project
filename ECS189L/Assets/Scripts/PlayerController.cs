using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Should input be handled from here?
    }


}