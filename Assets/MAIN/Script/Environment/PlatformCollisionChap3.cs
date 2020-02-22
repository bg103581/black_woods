using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollisionChap3 : MonoBehaviour
{
    [SerializeField]
    private Collider _colliderToIgnore;

    private bool _playerOnPlatform;

    [SerializeField]
    private Player _strixPlayer;
    [SerializeField]
    private Collider _strixColl;
    [SerializeField]
    private Collider _strixCollHead;
    [SerializeField]
    private Player _dotsPlayer;
    [SerializeField]
    private Collider _dotsColl;
    [SerializeField]
    private Collider _dotsCollHead;

    private void Update() {
        if (_playerOnPlatform) {
            if (_strixPlayer._move.y < 0) {
                Physics.IgnoreCollision(_colliderToIgnore, _strixColl, true);
                Physics.IgnoreCollision(_colliderToIgnore, _strixCollHead, true);
            }
            if (_dotsPlayer._move.y < 0) {
                Physics.IgnoreCollision(_colliderToIgnore, _dotsColl, true);
                Physics.IgnoreCollision(_colliderToIgnore, _dotsCollHead, true);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            _playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            _playerOnPlatform = false;
        }
    }
}
