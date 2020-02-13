using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        transform.parent.GetComponent<ActivateObject>().CollisionDetected(this, collision);
    }

    private void OnTriggerEnter(Collider other) {
        transform.parent.GetComponent<ActivateObject>().TriggerDetected(this, other);
    }
}
