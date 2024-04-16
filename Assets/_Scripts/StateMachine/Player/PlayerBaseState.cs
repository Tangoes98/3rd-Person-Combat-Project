using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine _playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        _playerStateMachine.CharacterController.Move((motion + _playerStateMachine.ForceReceiver.Movement) * deltaTime);
    }


}
