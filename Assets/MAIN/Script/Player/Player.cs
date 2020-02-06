using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Player : MonoBehaviour
{
    protected bool _isGrounded;
    protected bool _isGroundCollided;
    protected bool _onTree;
    protected bool _wallClimb;
    protected bool _isNextToHole;
    private bool _goRightWhenMaxLeft;
    private bool _goLeftWhenMaxRight;
    [HideInInspector]
    public bool IsLeft;

    [HideInInspector]
    public Vector2 _move;

    private float _oldX;
    protected float _moveX;
    protected float _moveY;

    private static CameraControl _cameraControl;

    protected Rigidbody _rb;

    protected Animator animator;

    protected Collider _col;

    [SerializeField]
    protected float _playerSpeed = 2;
    [SerializeField]
    protected float _jumpStrength;
    [SerializeField]
    protected float _fallMultiplier = 1.5f;
    [SerializeField]
    protected float _airControl = 2f;
    [SerializeField]
    protected Vector3 _bottomOffset;
    [SerializeField]
    protected float _collisionRadius;
    [SerializeField]
    protected LayerMask _groundLayer;

    protected bool _stopMoving;

    public float GetMoveX()
    {
        return _moveX;
    }
    
    //features that has to be put in update, common with Dots and Strix
    protected void PlayerUpdate() {
        _isGrounded = (Physics.OverlapSphere(transform.position + _bottomOffset, _collisionRadius, _groundLayer).Length != 0) && _isGroundCollided;
        _goRightWhenMaxLeft = (_cameraControl.IsToFar && IsLeft && (_moveX > 0));
        _goLeftWhenMaxRight = (_cameraControl.IsToFar && !IsLeft && (_moveX < 0));

        if (_isGrounded || _wallClimb) {
            //walk
            if (!_cameraControl.IsToFar || _goRightWhenMaxLeft || _goLeftWhenMaxRight) {
                if (_stopMoving) {
                    _rb.velocity = new Vector3(0, _rb.velocity.y, _rb.velocity.z);
                }
                else {
                    _rb.velocity = new Vector3(_moveX * _playerSpeed, _rb.velocity.y, _rb.velocity.z);
                }
            }

            if (_moveX != 0 && !_stopMoving) animator.SetBool("isRunning", true);
            else animator.SetBool("isRunning", false);

            if (_moveX < 0 && transform.rotation == Quaternion.Euler(0, 90f, 0)) {
                if (!_stopMoving) {
                    transform.rotation = Quaternion.Euler(0, 270f, 0);
                }
            } else if (_moveX > 0 && transform.rotation == Quaternion.Euler(0, 270f, 0)) {
                if (!_stopMoving) {
                    transform.rotation = Quaternion.Euler(0, 90f, 0);
                }
            }

            //dots utilise son bec
            if (_wallClimb) {
                _rb.velocity = new Vector3(0, _moveY * _playerSpeed, _rb.velocity.z);
            }
            _oldX = _moveX;
        }
        else {
            //aircontrol
            if (_oldX != _moveX) {
                if (_moveX > 0 && _rb.velocity.x < _playerSpeed)
                    _rb.AddForce(Vector3.right * _airControl, ForceMode.Force);
                else if (_moveX < 0 && _rb.velocity.x > (-1 * _playerSpeed))
                    _rb.AddForce(Vector3.left * _airControl, ForceMode.Force);
                else if (_moveX == 0 && Mathf.Abs(_rb.velocity.x) > 0.5f) {
                    if (_oldX < 0) {
                        _rb.AddForce(Vector3.right * _airControl, ForceMode.Force);
                    }
                    else if (_oldX > 0) {
                        _rb.AddForce(Vector3.left * _airControl, ForceMode.Force);
                    }
                }
            }
        }

        //speed up fall
        if (_rb.velocity.y < 0) {
            _rb.velocity += Vector3.up * Physics.gravity.y * _fallMultiplier * Time.deltaTime;
        }
    }

    protected void Init() {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        _cameraControl = FindObjectOfType<CameraControl>();
    }

    protected void Move(InputValue value) {
        if (Mathf.Abs(value.Get<Vector2>().x) < 0.4f)
            _moveX = 0f;
        else {
            if (value.Get<Vector2>().x > 0.4f) { _moveX = 1f; }
            else { _moveX = -1f; }
        }

        if (Mathf.Abs(value.Get<Vector2>().y) < 0.4f)
            _moveY = 0f;
        else {
            if (value.Get<Vector2>().y > 0.4f) { _moveY = 1f; }
            else { _moveY = -1f; }
        }

        _move = new Vector2(_moveX, _moveY);
    }

    protected void Jump() {

        if (!_stopMoving) {
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.velocity += Vector3.up * _jumpStrength;

            animator.SetBool("isJumping", true);
        }
    }

    public void DisableHorizontalMovement() {
        _stopMoving = true;
    }

    public void EnableHorizontalMovement() {
        _stopMoving = false;
    }

    public void IgnorePlatformCollision(Collider PlatformCollider) {
        Physics.IgnoreCollision(_col, PlatformCollider, true);
    }

    public void ResetIgnorePlatformCollision(Collider PlatformCollider) {
        Physics.IgnoreCollision(_col, PlatformCollider, false);
    }

    protected void CollisionEnter(Collision collision) {
        animator.SetBool("isJumping", false);
        if (collision.transform.tag == "ground") {
            _isGroundCollided = true;
        }
        if (collision.transform.tag == "tree")
            _onTree = true;
    }

    protected void CollisionExit(Collision collision) {
        if (collision.transform.tag == "ground") {
            _isGroundCollided = false;
        }
        if (collision.transform.tag == "tree")
            _onTree = false;
    }
    

    protected void CollisionStay(Collision collision) {
        if (collision.transform.tag == "ground") {
            _isGroundCollided = true;
        }
        if (collision.transform.tag == "tree")
            _onTree = true;
    }

    protected void DrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + _bottomOffset, _collisionRadius);
    }
}
