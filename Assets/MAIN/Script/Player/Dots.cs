using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dots : Player
{
    [SerializeField]
    private float _speedOnTree = 1f;
    private float _baseSpeed;

    private bool _isUsingBec;

    private void Awake() {
        Init();
        _baseSpeed = _playerSpeed;
        //_controls.Player.DotsMovement.performed += ctx => _move = new Vector2(ctx.ReadValue<float>(), 0);
        //_controls.Player.DotsMovement.canceled += ctx => _move = Vector2.zero;

        //_controls.Player.DotsJump.performed += ctx => Jump();
    }

    private void Update() {
        PlayerUpdate();

        if (_onTree && _isUsingBec) {    //si dots touche l'arbre et il appuie sur la touche "bec"
            _wallClimb = true;
            _playerSpeed = _speedOnTree;
            _rb.useGravity = false;
        } else {
            _wallClimb = false;
            _playerSpeed = _baseSpeed;
            _rb.useGravity = true;
        }
    }

    private void OnDotsMovement(InputValue value) {
        _move = new Vector2(value.Get<Vector2>().x, value.Get<Vector2>().y);
    }

    private void OnDotsJump() {
        if (_isGrounded) {
            //make the jump
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.velocity += Vector3.up * _jumpStrength;
        }
    }

    private void OnDotsBec(InputValue value) {
        _isUsingBec = value.Get<float>() > 0;
    }
}
