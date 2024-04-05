using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action JumpEvent;
    public event Action DodgeEvent;
    public Vector2 MovementValue { get; private set; }

    Controls controls;

    void Start()
    {
        controls = new();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    void Update()
    {

    }

    void OnDestroy()
    {
        controls.Player.Disable();
    }





    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnFreeLook(InputAction.CallbackContext context)
    {
        
    }
}
