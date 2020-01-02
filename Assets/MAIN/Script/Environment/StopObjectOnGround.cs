using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StopObjectOnGround : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "ground") {
            StopObject();
        }
    }

    private void StopObject() {
        _rb.useGravity = false;
        _rb.velocity = Vector3.zero;
    }
}
