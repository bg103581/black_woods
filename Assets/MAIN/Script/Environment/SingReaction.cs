using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class SingReaction : MonoBehaviour {
    [SerializeField]
    private Transform _fireflyPos;
    [SerializeField]
    private Transform _StrixPosOnDragonfly;
    [SerializeField]
    private Transform _dragonflyPos;
    [SerializeField]
    private Transform _dragonflyRotatePos;
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
            transform.DOLocalJump(Vector3.zero, 0, 1, 1.5f).OnComplete(() => EndDOJump(transform, _fireflyPos));
            //transform.DOLocalMove(Vector3.zero, 1.5f).OnComplete(() => EndDOJump(transform, _fireflyPos));
        } else if (name == "Dragonfly") {
            checkScarabossState = true;
        } else if (name == "Ent_1") {
            GetComponentInChildren<TurnEnt>().TurnLeft();
        }
    }

    private void Update() {
        if (checkScarabossState && (name == "Dragonfly")) {
            if (GetComponent<Usable>().isDetected) {
                if (_dotsTransform.GetComponent<Dots>().isOnStrixHead) {
                    Debug.Log("Dragonfly ready");
                    if (_strixTransform.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("idle")) {
                        _strixTransform.SetParent(_StrixPosOnDragonfly);
                        _strixTransform.GetComponent<Rigidbody>().useGravity = false;
                        _strixTransform.GetComponent<PlayerInput>().PassivateInput();
                        _dotsTransform.GetComponent<PlayerInput>().PassivateInput();
                        _strixTransform.DOJump(_StrixPosOnDragonfly.position, 2, 1, 2f);
                        checkScarabossState = false;
                        StartCoroutine(Fly());
                    }
                }
            }
        }
    }

    IEnumerator Fly() {
        GetComponentInChildren<Animator>().SetBool("isFlying", true);

        yield return new WaitForSeconds(3);
        transform.DORotate(_dragonflyRotatePos.rotation.eulerAngles, 2);

        yield return new WaitForSeconds(2);
        transform.DOJump(_dragonflyPos.position, 2, 1, 3f);

        yield return new WaitForSeconds(4);
        _strixTransform.SetParent(null);
        _strixTransform.DOJump(_strixLandPos.position, 2, 1, 2f).OnComplete(() => _strixTransform.GetComponent<Rigidbody>().useGravity = true);

        _strixTransform.GetComponent<PlayerInput>().ActivateInput();
        _dotsTransform.GetComponent<PlayerInput>().ActivateInput();

        GetComponentInChildren<Animator>().SetBool("isFlying", false);

        StopAllCoroutines();
    }

    private void EndDOJump(Transform toChange, Transform reference) {
        //animator.SetBool("isJumping", false);
        toChange.localScale = reference.localScale;
        toChange.position = reference.position;
        toChange.rotation = reference.rotation;

        toChange.gameObject.GetComponent<Animator>().enabled = true;
    }

    public void Shake() {
        transform.DOShakePosition(3f, 0.1f, 1, 90f);
    }
}
