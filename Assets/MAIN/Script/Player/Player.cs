using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    protected PlayerControls _controls;

    protected bool _isGrounded;

    protected Vector2 _move;

    [SerializeField]
    protected float _playerSpeed = 2;
    [SerializeField]
    protected float _jumpStrength;
    protected Rigidbody _rb;

    protected void Init() {
        _controls = new PlayerControls();
        _rb = GetComponent<Rigidbody>();
    }

    protected void Jump() {
        if (_isGrounded)
            _rb.AddForce(Vector3.up * _jumpStrength);
    }

    private void OnEnable() {
        _controls.Player.Enable();
    }

    private void OnDisable() {
        _controls.Player.Disable();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "ground")
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.transform.tag == "ground")
            _isGrounded = false;
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.transform.tag == "ground")
            _isGrounded = true;
    }
}
