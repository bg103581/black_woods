using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoMoveOnBec : MonoBehaviour
{
    [SerializeField]
    private Transform _objectToMove;
    [SerializeField]
    private Transform _targetMove;
    [SerializeField]
    private GameObject _branchCollider;
    [SerializeField]
    private Collider _baseCollider;
    [SerializeField]
    private Collider _colliderSuccess;
    [SerializeField]
    private float _duration;

    [HideInInspector]
    public bool _isBroken;

    public void OnBecHit() {
        if (!_isBroken) {
            Debug.Log("hit by Dots");
            _isBroken = true;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(_objectToMove.DOMove(_targetMove.position, _duration).SetEase(Ease.Linear));
            sequence.Join(_objectToMove.DORotate(_targetMove.rotation.eulerAngles, _duration).SetEase(Ease.Linear));
            sequence.OnComplete(() => CompleteSequence());

            sequence.Play();
        }
    }

    private void CompleteSequence() {
        _branchCollider.SetActive(true);
        _baseCollider.enabled = false;
        _colliderSuccess.enabled = true;
    }
}
