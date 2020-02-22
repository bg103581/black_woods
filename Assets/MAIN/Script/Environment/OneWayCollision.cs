using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
    [SerializeField]
    private Collider _platformCollider;
    
    [SerializeField]
    private Collider _strixColl;
    [SerializeField]
    private Collider _strixCollHead;
    [SerializeField]
    private Collider _dotsColl;
    [SerializeField]
    private Collider _dotsCollHead;

    private void OnTriggerEnter(Collider other) {
        if (other.name == "Strix") {
            Physics.IgnoreCollision(_platformCollider, _strixColl, true);
            Physics.IgnoreCollision(_platformCollider, _strixCollHead, true);
        }
        else if (other.name == "Dots") {
            Physics.IgnoreCollision(_platformCollider, _dotsColl, true);
            Physics.IgnoreCollision(_platformCollider, _dotsCollHead, true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.name == "Strix") {
            Physics.IgnoreCollision(_platformCollider, _strixColl, false);
            Physics.IgnoreCollision(_platformCollider, _strixCollHead, false);
        }
        else if (other.name == "Dots") {
            Physics.IgnoreCollision(_platformCollider, _dotsColl, false);
            Physics.IgnoreCollision(_platformCollider, _dotsCollHead, false);
        }
    }
}
