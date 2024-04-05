using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    public readonly int FREE_LOOK_SPEED = Animator.StringToHash("FreeLookSpeed");

    public PlayerFreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();



        _playerStateMachine.CharacterController.Move(movement * _playerStateMachine.FreelookMovementSpeed * deltaTime);

        if (_playerStateMachine.InputReader.MovementValue == Vector2.zero)
        {
            // Unit Movement
            _playerStateMachine.Animator.SetFloat(FREE_LOOK_SPEED, 0, .1f, deltaTime);
            return;
        }

        _playerStateMachine.Animator.SetFloat(FREE_LOOK_SPEED, 1, .1f, deltaTime);

        FaceDirection(movement);

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





}
