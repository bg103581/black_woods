using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MushroomTriggerClouds : MonoBehaviour
{

    private bool _hasTriggered;
    [SerializeField]
    private GameObject[] _objectsToEnable;
    [SerializeField]
    private Animator _crossFade;
    [SerializeField]
    private PlayerInput _strixInput;
    [SerializeField]
    private PlayerInput _dotsInput;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (!_hasTriggered) {
                _hasTriggered = true;
                _strixInput.enabled = false;
                _dotsInput.enabled = false;
                StartCoroutine("CloudCorout");
                _crossFade.Play("CrossFade_Start");
            }
        }
    }

    private IEnumerator CloudCorout() {
        yield return new WaitForSeconds(1f);

        _strixInput.enabled = true;
        _dotsInput.enabled = true;
        foreach (GameObject obj in _objectsToEnable) {
            obj.SetActive(true);
        }
    }
}
