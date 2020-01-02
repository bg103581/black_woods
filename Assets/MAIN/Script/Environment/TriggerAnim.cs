using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Strix") {
            _animator.Play("Chap1Scene3Tree");
        }
    }
}
