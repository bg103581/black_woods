using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{

    private bool _isBroken;

    private Rigidbody _rb;
    private BoxCollider _coll;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBecHit() {
        if (!_isBroken) {
            Debug.Log("hit by Dots");
            _isBroken = true;

            _rb.useGravity = true;
            _coll.isTrigger = false;
        }
    }
}
