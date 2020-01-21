using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnim : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animationName;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Strix") {
            _animator.Play(_animationName);
        }
    }
}
