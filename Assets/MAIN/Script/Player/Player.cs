using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class Player : MonoBehaviour
{
    protected bool _isGrounded;
    protected bool _onTree;
    protected bool _wallClimb;
    protected bool _isNextToHole;

    protected Vector2 _move;

    private float _oldX;

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

    //features that has to be put in update, common with Dots and Strix
    protected void PlayerUpdate() {
        //_isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + (Vector2)_bottomOffset, _collisionRadius, _groundLayer);
        _isGrounded = Physics.OverlapSphere(transform.position + _bottomOffset, _collisionRadius, _groundLayer).Length != 0;

        if (_isGrounded || _wallClimb) {
            //walk
            _rb.velocity = new Vector3(_move.x * _playerSpeed, _rb.velocity.y, _rb.velocity.z);

            if (_rb.velocity.x < 0 && transform.rotation == Quaternion.Euler(0,90f,0)) {
                transform.rotation = Quaternion.Euler(0, 270f, 0);

            }
            else if (_rb.velocity.x > 0 && transform.rotation == Quaternion.Euler(0, 270f, 0)) {
                transform.rotation = Quaternion.Euler(0, 90f, 0);
            }

            //dots utilise son bec
            if (_wallClimb) {
                _rb.velocity = new Vector3(0, _move.y * _playerSpeed, _rb.velocity.z);
            }
            _oldX = _move.x;
        }
        else {
            //aircontrol
            if (_oldX != _move.x) {
                if (_move.x > 0 && _rb.velocity.x < _playerSpeed)
                    _rb.AddForce(Vector3.right * _airControl, ForceMode.Force);
                else if (_move.x < 0 && _rb.velocity.x > (-1 * _playerSpeed))
                    _rb.AddForce(Vector3.left * _airControl, ForceMode.Force);
                else if (_move.x == 0 && Mathf.Abs(_rb.velocity.x) > 0.5f) {
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
    }

    private void OnCollisionEnter(Collision collision) {
        //if (collision.transform.tag == "ground")
        //    _isGrounded = true;
            animator.SetBool("isJumping", false);
        if (collision.transform.tag == "tree")
            _onTree = true;
    }

    private void OnCollisionExit(Collision collision) {
        //if (collision.transform.tag == "ground")
        //    _isGrounded = false;
        animator.SetBool("isJumping", true);
        if (collision.transform.tag == "tree")
            _onTree = false;
    }

    private void OnCollisionStay(Collision collision) {
        //if (collision.transform.tag == "ground")
        //    _isGrounded = true;
        if (collision.transform.tag == "tree")
            _onTree = true;
    }

    protected void DrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + _bottomOffset, _collisionRadius);
    }
}
