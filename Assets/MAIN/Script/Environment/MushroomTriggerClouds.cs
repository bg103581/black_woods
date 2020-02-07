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
    //[SerializeField]
    public PlayerInput _strixInput;
    //[SerializeField]
    public PlayerInput _dotsInput;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (!_hasTriggered) {
                _hasTriggered = true;
                _strixInput.PassivateInput();
                _dotsInput.PassivateInput();
                StartCoroutine("CloudCorout");
                _crossFade.Play("CrossFade_Start");
            }
        }
    }

    private IEnumerator CloudCorout() {
        yield return new WaitForSeconds(1f);

        _strixInput.ActivateInput();
        _dotsInput.ActivateInput();
        foreach (GameObject obj in _objectsToEnable) {
            obj.SetActive(true);
        }
    }
}
