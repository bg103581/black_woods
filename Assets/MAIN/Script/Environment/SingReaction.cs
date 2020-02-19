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

    private Sequence fireflySequence;
    private Transform upPos, downPos;

    private void Start() {
        if (name == "Firefly") {
            InitSequence(false);
        }
    }

    public void React() {
        if (name == "Firefly") {
            fireflySequence.Kill();

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
                Debug.Log("Dragonfly ready");
                //if (_strixTransform.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("idle")) {
                //    checkScarabossState = false;
                //    StartCoroutine(Fly());
                //}
                _strixTransform.GetComponent<PlayerInput>().PassivateInput();
                _dotsTransform.GetComponent<PlayerInput>().PassivateInput();
                _dotsTransform.GetComponent<Dots>().MoveToStrixHead();
                checkScarabossState = false;
                StartCoroutine(Fly());
            }
        }
    }

    IEnumerator Fly() {

        transform.DORotate(_dragonflyRotatePos.rotation.eulerAngles, 2);

        yield return new WaitForSeconds(3);

        _strixTransform.SetParent(_StrixPosOnDragonfly);
        _strixTransform.GetComponent<Rigidbody>().useGravity = false;
        _strixTransform.DOJump(_StrixPosOnDragonfly.position, 2, 1, 1.5f);
        _strixTransform.DORotate(Quaternion.Euler(0f, 90f, 0f).eulerAngles, 1f);
        _strixTransform.GetComponent<Animator>().SetTrigger("triggerIsJumping");

        GetComponentInChildren<Animator>().SetBool("isFlying", true);
        
        yield return new WaitForSeconds(2);
        transform.DOJump(_dragonflyPos.position, 2, 1, 3f);

        yield return new WaitForSeconds(4);
        _strixTransform.SetParent(null);
        _strixTransform.GetComponent<Animator>().SetTrigger("triggerIsJumping");
        _strixTransform.DOJump(_strixLandPos.position, 2, 1, 1.5f).OnComplete(() => _strixTransform.GetComponent<Rigidbody>().useGravity = true);

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

        InitSequence(true);
    }

    private void InitSequence(bool isLocal) {
        upPos = transform.Find("UpPos");
        downPos = transform.Find("DownPos");

        fireflySequence = DOTween.Sequence();
        fireflySequence.SetLoops(-1);

        if (isLocal) {
            fireflySequence.Append(transform.DOLocalMove(upPos.localPosition, 1.7f).SetEase(Ease.InOutSine));
            fireflySequence.Append(transform.DOLocalMove(downPos.localPosition, 1.7f).SetEase(Ease.InOutSine));
        }
        else {
            fireflySequence.Append(transform.DOMove(upPos.position, 1.7f).SetEase(Ease.InOutSine));
            fireflySequence.Append(transform.DOMove(downPos.position, 1.7f).SetEase(Ease.InOutSine));
        }

        fireflySequence.Play();
    }
}
