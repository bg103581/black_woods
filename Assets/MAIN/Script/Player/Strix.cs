using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.InputSystem;

public class Strix : Player
{

    [SerializeField]
    private float _flairRadius = 5f;
    [SerializeField]
    private StrixObjectDetector _objectDetector;
    
    private int _layerMaskFlair = 1 << 9;

    [HideInInspector]
    public bool isCoop;

    private GameObject nearestObj;
    private GameObject _holeToDig;
    private GameObject _objectToCatch;
    private bool _isCatchPressed;
    private Quaternion _strixRotation;
    [SerializeField]
    private Collider _coopCollider;

    //[HideInInspector]
    public bool coopIsUnlock, flairIsUnlock, creuseIsUnlock, catchIsUnlock;

    private void Awake() {
        Init();

        //_controls.Player.StrixMovement.performed += ctx => _move = new Vector2(ctx.ReadValue<float>(), 0);
        //_controls.Player.StrixMovement.canceled += ctx => _move = Vector2.zero;

        //_controls.Player.StrixJump.performed += ctx => Jump();
    }

    private void Update() {
        PlayerUpdate();

        if (isCoop) {
            _coopCollider.enabled = true;
        }
        else {
            _coopCollider.enabled = false;
        }

        if (_objectDetector != null) _objectToCatch = _objectDetector.GetObjectToCatch();
        if (_isCatchPressed)
        {
            transform.rotation = _strixRotation;
        }
    }

    private void OnStrixMovement(InputValue value) {
        Move(value);
    }

    private void OnStrixJump() {
        if (_isGrounded) {
            //make the jump
            Jump();
        }
    }

    private void OnStrixCatch()
    {
        if (catchIsUnlock) {
            _isCatchPressed = !_isCatchPressed;
            _strixRotation = transform.rotation;
            animator.SetBool("isCatching", _isCatchPressed);
            if (_objectToCatch != null) {
                _objectToCatch.GetComponent<ObjectCatchable>().DragItem();
            }
        }
    }
     
    
    private void OnStrixFlair() {
        if (flairIsUnlock) {
            Collider[] nearObjects = Physics.OverlapSphere(transform.position, _flairRadius, _layerMaskFlair);

            if (nearObjects.Length == 1) {
                nearestObj = nearObjects[0].gameObject;
            }
            else if (nearObjects.Length > 1) {  //trouver l'objet le plus proche qui n'est pas deja detecté
                float minDistance = 100f;
                foreach (Collider obj in nearObjects) {
                    float distance = Vector3.Distance(transform.position, obj.transform.position);
                    if (distance <= minDistance && !obj.GetComponent<Usable>().isDetected) {
                        minDistance = distance;
                        nearestObj = obj.gameObject;
                    }
                }
            }

            if (nearestObj != null) {
                nearestObj.GetComponent<Usable>().OnDetected();
            }

            animator.SetTrigger("isFlairing");

        }

       
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _flairRadius);
        DrawGizmos();
    }

    private void OnStrixCreuse() {
        animator.SetTrigger("isDigging");

        if (_isNextToHole && _holeToDig != null) {
            _holeToDig.GetComponent<EnablePathObject>().EnablePath();
        }
    }

    private void OnStrixCoop(InputValue value) {
        if (coopIsUnlock) {
            isCoop = value.Get<float>() > 0;
            Debug.Log("(Strix) : _isCoop = " + isCoop);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "creuse_object") {
            _isNextToHole = true;
            _holeToDig = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "creuse_object") {
            _isNextToHole = false;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "creuse_object") {
            _isNextToHole = true;
        }
    }
}
