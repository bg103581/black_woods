using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField]
    private Collider _stoneCollider;
    [SerializeField]
    private Collider _platformCollider;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(_stoneCollider, _platformCollider, true);
    }
}
