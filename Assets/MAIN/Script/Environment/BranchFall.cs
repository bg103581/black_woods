using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BranchFall : MonoBehaviour
{
    [SerializeField]
    private Transform endPosTransform;
    [SerializeField]
    private float doDuration;

    private bool isFallen = false;

    private void OnTriggerEnter(Collider other) {
        if (!isFallen) {
            if (other.name == "Strix") {
                transform.DORotate(endPosTransform.rotation.eulerAngles, doDuration);
                isFallen = true;
            }
        }
    }
}
