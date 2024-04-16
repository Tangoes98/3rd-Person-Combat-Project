using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    // public readonly int Attack_01_Hash = Animator.StringToHash("Attack_01");
    Attack _attack;
    public PlayerAttackState(PlayerStateMachine playerStateMachine, int attackIndex) : base(playerStateMachine)
    {
        _playerStateMachine.CurrentState = "ATTACK_STATE";
        _attack = _playerStateMachine.Attakcs[attackIndex];
    }

    public override void Enter()
    {
        _playerStateMachine.Animator.CrossFadeInFixedTime(_attack.AnimationName, _attack.TransitionDuration);
    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime();

        if (normalizedTime < 1f) return;
        else
        {
            _playerStateMachine.SwitchState(new PlayerFreeLookState(_playerStateMachine));
        }

    }

    float GetNormalizedTime()
    {
        var currentStateInfo = _playerStateMachine.Animator.GetCurrentAnimatorStateInfo(0);

        if (!_playerStateMachine.Animator.IsInTransition(0))
        {
            return currentStateInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }




    }

}
