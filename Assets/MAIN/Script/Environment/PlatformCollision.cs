using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use to ignore collision when pressing down
public class PlatformCollision : MonoBehaviour
{
    [SerializeField]
    private Collider _colliderToIgnore;
    
    private bool _playerOnPlatform;

    [SerializeField]
    private Player _strixPlayer;
    [SerializeField]
    private Player _dotsPlayer;

    private void Update() {
        if (_playerOnPlatform) {
            if (_strixPlayer._move.y < 0) {
                _strixPlayer.IgnorePlatformCollision(_colliderToIgnore);
            }
            if (_dotsPlayer._move.y < 0) {
                _dotsPlayer.IgnorePlatformCollision(_colliderToIgnore);
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
