using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    float _verticalVelocity;

    public Vector3 Movement => Vector3.up * _verticalVelocity;

    private void Update()
    {
        if (_verticalVelocity < 0 && _controller.isGrounded)
        {
            _verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
