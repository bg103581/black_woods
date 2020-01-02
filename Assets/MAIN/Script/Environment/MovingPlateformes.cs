using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlateformes : MonoBehaviour
{

    [SerializeField]
    private Transform _startTransform;
    [SerializeField]
    private Transform _endTransform;
    [SerializeField]
    private float _timeToMove = 2f;
    
    void Start()
    {
        MoveToEndPosition(_timeToMove);
    }

    void MoveToEndPosition(float time) {
        transform.DOMove(_endTransform.position, time).SetEase(Ease.InOutSine).OnComplete(() => MoveToStartPosition(_timeToMove));
    }

    void MoveToStartPosition(float time) {
        transform.DOMove(_startTransform.position, time).SetEase(Ease.InOutSine).OnComplete(() => MoveToEndPosition(_timeToMove));
    }

    private void OnCollisionEnter(Collision collision) {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision) {
        collision.transform.parent = null;
    }
}
