using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public static InputReader Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of InputReader");
        }
        Instance = this;
    }

    public event Action JumpEvent;
    public event Action DodgeEvent;
    public event Action AttackEvent;
    public event Action MenuEvent;
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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AttackEvent?.Invoke();
    }

    public void OnMenu(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        MenuEvent?.Invoke();
    }
}
