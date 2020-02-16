using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SingReaction : MonoBehaviour {
    [SerializeField]
    private Transform _fireflyPos;
    [SerializeField]
    private Transform _StrixPosOnScaraboss;
    [SerializeField]
    private Transform _scarabossPos;
    [SerializeField]
    private Transform _strixLandPos;
    [SerializeField]
    private Transform _dotsTransform;
    [SerializeField]
    private Transform _strixTransform;

    private bool checkScarabossState = false;

    public void React() {
        if (name == "Firefly") {
            transform.SetParent(_fireflyPos);
            transform.DOJump(_fireflyPos.position, 0, 1, 2f).OnComplete(() => EndDOJump(transform, _fireflyPos));
        } else if (name == "Scaraboss") {
            checkScarabossState = true;
        } else if (name == "Ent_1") {
            GetComponentInChildren<TurnEnt>().TurnLeft();
        }
    }

    private void Update() {
        if (checkScarabossState && (name == "Scaraboss")) {
            if (GetComponent<Usable>().isDetected) {
                if (_dotsTransform.GetComponent<Dots>().isOnStrixHead) {
                    Debug.Log("Scaraboss ready");
                    if (_strixTransform.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("idle")) {
                        _strixTransform.SetParent(_StrixPosOnScaraboss);
                        _strixTransform.GetComponent<Rigidbody>().useGravity = false;
                        _strixTransform.DOJump(_StrixPosOnScaraboss.position, 2, 1, 2f);
                        checkScarabossState = false;
                        StartCoroutine(Fly());
                    }
                }
            }
        }
    }

    IEnumerator Fly() {
        yield return new WaitForSeconds(3);
        transform.DOJump(_scarabossPos.position, 3, 1, 3f);

        yield return new WaitForSeconds(4);
        _strixTransform.SetParent(null);
        _strixTransform.DOJump(_strixLandPos.position, 2, 1, 2f).OnComplete(() => _strixTransform.GetComponent<Rigidbody>().useGravity = true);
        StopAllCoroutines();
    }

    private void EndDOJump(Transform toChange, Transform reference) {
        //animator.SetBool("isJumping", false);
        toChange.localScale = reference.localScale;
        toChange.position = reference.position;
        toChange.rotation = reference.rotation;
    }
}
