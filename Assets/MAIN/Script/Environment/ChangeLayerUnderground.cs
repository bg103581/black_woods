using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerUnderground : MonoBehaviour
{
    [SerializeField]
    private GameObject _dots;
    [SerializeField]
    private GameObject _hole;
    [SerializeField]
    private GameObject _root;
    [Range(0,31)]
    [SerializeField]
    private int _playerUnderground;
    [Range(0, 31)]
    [SerializeField]
    private int _player;
    [Range(0, 31)]
    [SerializeField]
    private int _underGround;
    [Range(0, 31)]
    [SerializeField]
    private int _default;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Dots") {
            _dots.layer = _playerUnderground;
            _hole.layer = _underGround;
            _root.layer = _playerUnderground;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.name == "Dots") {
            _dots.layer = _player;
            _hole.layer = _default;
            _root.layer = _default;
        }
    }

}
