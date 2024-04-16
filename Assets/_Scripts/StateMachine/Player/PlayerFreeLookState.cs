using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    public readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");

    public PlayerFreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
        _playerStateMachine.CurrentState = "FREE_LOOK_STATE";
    }

    public override void Enter()
    {
        _playerStateMachine.Animator.CrossFadeInFixedTime("FreeLookBlendTree", .1f);
        _playerStateMachine.InputReader.AttackEvent += OnAttackEvent;
    }

    public override void Exit()
    {
        _playerStateMachine.InputReader.AttackEvent -= OnAttackEvent;

    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        Move(movement * _playerStateMachine.FreelookMovementSpeed, deltaTime);


        if (_playerStateMachine.InputReader.MovementValue == Vector2.zero)
        {
            // Unit Movement
            _playerStateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, .1f, deltaTime);
            return;
        }

        _playerStateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, .1f, deltaTime);

        FaceDirection(movement);

    }

    #region ===========

    void OnAttackEvent()
    {
        _playerStateMachine.SwitchState(new PlayerAttackState(_playerStateMachine, 0));
    }





    private void FaceDirection(Vector3 movement)
    {
        //_playerStateMachine.transform.rotation = Quaternion.LookRotation(movement);
        _playerStateMachine.transform.forward =
            Vector3.Slerp(_playerStateMachine.transform.forward,
                            movement,
                            _playerStateMachine.FreelookRotationSpeed * Time.deltaTime);
    }

    Vector3 CalculateMovement()
    {
        Vector3 movement = new();

        Vector3 forward = _playerStateMachine.MainCameraTransform.forward.normalized;
        Vector3 right = _playerStateMachine.MainCameraTransform.right.normalized;

        forward.y = 0f;
        right.y = 0f;



        movement.x = _playerStateMachine.InputReader.MovementValue.x;
        //movement.y = 0f;
        movement.z = _playerStateMachine.InputReader.MovementValue.y;

        return forward * movement.z + right * movement.x;

    }

    #endregion




}
