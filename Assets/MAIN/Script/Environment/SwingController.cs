using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    [SerializeField] private Transform _swingChild;
    private const float RETURN_SWING_SPEED = 0.05f;
    private float _timeSinceStrixLeft;
    private float _timeSinceStrixOn = 1;
    private enum SwingPhase
    {
        TO_RIGHT,
        TO_LEFT,
        STOP
    }

    private SwingPhase currentSwingPhase = SwingPhase.STOP;
    private SwingPlayerDetector _playerDetector;
    private void Start()
    {
        _playerDetector = _swingChild.GetComponent<SwingPlayerDetector>();
    }

    private void Update()
    {
        if(_playerDetector.GetStrix()!=null)
        {
            _timeSinceStrixLeft = 0;
            UpdateSwingPhase();
            UpdateSwingRotation();
        }
        else
        {
            BackToOriginRotation();
        }
        _swingChild.rotation = transform.rotation * Quaternion.Inverse(transform.rotation);
    }

    private void UpdateSwingPhase()
    {
        switch (currentSwingPhase)
        {
            case SwingPhase.STOP:
                currentSwingPhase = SwingPhase.TO_RIGHT;
                break;
            case SwingPhase.TO_RIGHT when transform.rotation.z >= Quaternion.Euler(0,0,85).z:
                currentSwingPhase = SwingPhase.TO_LEFT;
                break;
            case SwingPhase.TO_LEFT when transform.rotation.z <= Quaternion.Euler(0,0,-85).z:
                currentSwingPhase = SwingPhase.TO_RIGHT;
                break;
            default:
                break;
        }
    }

    private void UpdateSwingRotation()
    {
        switch (currentSwingPhase)
        {
            case SwingPhase.TO_RIGHT :
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,90),RETURN_SWING_SPEED * _timeSinceStrixOn);
                break;
            case SwingPhase.TO_LEFT :
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,-90),RETURN_SWING_SPEED * _timeSinceStrixOn);
                break;
            case SwingPhase.STOP:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void BackToOriginRotation()
    {
        if(transform.rotation != new Quaternion(0,0,0,1))
        {
            _timeSinceStrixLeft += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(0, 0, 0, 1),
                RETURN_SWING_SPEED * _timeSinceStrixLeft);
        }
        else
        {
            currentSwingPhase = SwingPhase.STOP;
        }
    }
}
