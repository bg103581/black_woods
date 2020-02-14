using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SingReaction : MonoBehaviour {
    [SerializeField]
    private Transform _fireflyPos;

    public void React() {
        if (name == "Firefly") {
            transform.SetParent(_fireflyPos);
            transform.DOJump(_fireflyPos.position, 0, 1, 2f).OnComplete(() => EndMoveToStrixHead());
        }
    }

    private void EndMoveToStrixHead() {
        //animator.SetBool("isJumping", false);
        transform.localScale = _fireflyPos.localScale;
        transform.position = _fireflyPos.position;
        transform.rotation = _fireflyPos.rotation;
    }
}
