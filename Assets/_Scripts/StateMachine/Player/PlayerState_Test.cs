using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Test : PlayerBaseState
{
    public PlayerState_Test(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Tick");
    }

}
