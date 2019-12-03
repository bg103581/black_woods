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
    private bool _isNearHeadStrix;
    private bool _isOnStrixHead;

    private GameObject _objectToHit;

    [SerializeField]
    private Transform _strix;
    [SerializeField]
    private Transform _strixHead;

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
        } 
        else if (_isOnStrixHead) {      //si dots est sur Strix
            _rb.useGravity = false;
        }
        else {
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
        if (_objectToHit != null) {
            _objectToHit.GetComponent<BreakObject>().OnBecHit();
        }
    }

    private void OnDotsCoop() {
        if (_isNearHeadStrix) {
            Debug.Log("monte sur strix");
            MoveToStrixHead();
        }
        else if (_isOnStrixHead && _strix.gameObject.GetComponent<Strix>().isCoop) {
            Debug.Log("descend de strix");
            GetDownFromStrix();
        }
    }

    private void MoveToStrixHead() {
        _isOnStrixHead = true;

        transform.SetParent(_strix);

        transform.position = _strixHead.position;
        _rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void GetDownFromStrix() {
        _isOnStrixHead = false;

        transform.parent = null;

        _rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "break_object") {
            _objectToHit = other.gameObject;
        }
        if (other.tag == "head_strix") {
            _isNearHeadStrix = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "break_object") {
            _objectToHit = null;
        }
        if (other.tag == "head_strix") {
            _isNearHeadStrix = false;
        }
    }
}
