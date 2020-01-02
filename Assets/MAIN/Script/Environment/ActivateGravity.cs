using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BreakObject))]
public class ActivateGravity : MonoBehaviour
{
    private bool _isPlayed;

    [SerializeField]
    private GameObject _objectToUseGravity;
    private BreakObject _breakOject;

    private void Start() {
        _breakOject = GetComponent<BreakObject>();
    }

    private void Update() {
        if (_breakOject._isBroken) {
            Play();
        }
    }

    public void Play() {
        if (!_isPlayed) {
            _objectToUseGravity.GetComponent<Rigidbody>().useGravity = true;
            _isPlayed = true;
        }
    }
}
