using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollision : MonoBehaviour
{
    [SerializeField]
    private Collider _platformCollider;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().IgnorePlatformCollision(_platformCollider);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<Player>().ResetIgnorePlatformCollision(_platformCollider);
        }
    }
}
