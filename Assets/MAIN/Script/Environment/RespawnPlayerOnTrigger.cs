using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RespawnPlayerOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _posToRespawn;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.transform.position = _posToRespawn.position;
        }
    }
}
