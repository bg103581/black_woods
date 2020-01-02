using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DisableColliderOnBreak : MonoBehaviour
{
    private Collider _coll;
    public BreakObject _breakObject;

    void Start()
    {
        _coll = GetComponent<Collider>();
    }

    private void Update() {
        if (_breakObject._isBroken && _coll.enabled) {
            DisableCollider();
        }
    }

    private void DisableCollider() {
        _coll.enabled = false;
    }
}
