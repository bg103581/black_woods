using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dots : Player
{
    private void Awake() {
        Init();

        //_controls.Player.DotsMovement.performed += ctx => _move = new Vector2(ctx.ReadValue<float>(), 0);
        //_controls.Player.DotsMovement.canceled += ctx => _move = Vector2.zero;

        //_controls.Player.DotsJump.performed += ctx => Jump();
    }

    private void Update() {
        PlayerUpdate();
    }

    private void OnDotsMovement(InputValue value) {
        _move = new Vector2(value.Get<Vector2>().x, 0);
    }

    private void OnDotsJump() {
        if (_isGrounded) {
            //make the jump
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.velocity += Vector3.up * _jumpStrength;
        }
    }
}
