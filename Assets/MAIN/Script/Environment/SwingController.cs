using System;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    [SerializeField] private Transform _swingChild;
    private const float RETURN_SWING_SPEED = 0.05f;
    private float _timeSinceStrixLeft;
    private float _timeSinceStrixOn = 1;
    
    [Range(-90,0)] private float angleLeftToReach = -20;
    [Range(0,90)] private float angleRightToReach = 20;

    private Strix strix;
    private float currentAngleLeftToReach = -20;
    private float currentAngleRightToReach = 20;
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
            strix = _playerDetector.GetStrix().GetComponent<Strix>();
            _timeSinceStrixLeft = 0;
            _timeSinceStrixOn += Time.deltaTime;
            UpdateSwingPhase();
            UpdateAngleToReach();
            UpdateCurrentAngleToReach();
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
            case SwingPhase.STOP :
                if(angleRightToReach != 0)
                {
                    currentSwingPhase = SwingPhase.TO_RIGHT;
                }
                else if(angleLeftToReach != 0)
                {
                    currentSwingPhase = SwingPhase.TO_RIGHT;
                }
                break;
            case SwingPhase.TO_RIGHT when IsNear(transform.rotation.eulerAngles.z,currentAngleRightToReach,5):
                print("ReachRight");
                _timeSinceStrixOn = 0;
                currentSwingPhase = SwingPhase.TO_LEFT;
                break;
            case SwingPhase.TO_LEFT when IsNear(transform.rotation.eulerAngles.z - 360,currentAngleLeftToReach,5):
                print("ReachLeft");
                _timeSinceStrixOn = 0;
                currentSwingPhase = SwingPhase.TO_RIGHT;
                break;
            default :
                if (IsNear(angleLeftToReach,angleRightToReach,0) && IsNear(angleLeftToReach,0,0))
                {
                    currentSwingPhase = SwingPhase.STOP;
                }
                break;
        }
    }

    private void UpdateSwingRotation()
    {
        Quaternion angle;
        switch (currentSwingPhase)
        {
            case SwingPhase.TO_RIGHT :
                angle = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, currentAngleRightToReach), RETURN_SWING_SPEED * _timeSinceStrixOn);
                transform.rotation = angle;
                break;
            case SwingPhase.TO_LEFT :
                angle = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, currentAngleLeftToReach), RETURN_SWING_SPEED * _timeSinceStrixOn);
                transform.rotation = angle;
                break;
            case SwingPhase.STOP:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UpdateCurrentAngleToReach()
    {
        if (currentSwingPhase == SwingPhase.TO_RIGHT && IsNear(transform.rotation.eulerAngles.z,0,2))
        {
            currentAngleRightToReach = angleRightToReach;
        }

        if (currentSwingPhase == SwingPhase.TO_LEFT && IsNear(transform.rotation.eulerAngles.z, 0, 2))
        {
            currentAngleLeftToReach = angleLeftToReach;
        }
    }

    private void UpdateAngleToReach()
    {
        if (strix.GetMoveX() > 0 && transform.rotation.z < 0)
        {
            angleRightToReach += 20 * Time.deltaTime;
            angleLeftToReach += 4 * Time.deltaTime;
        }
        else if (strix.GetMoveX() < 0 && transform.rotation.z > 0)
        {
            angleLeftToReach -= 20 * Time.deltaTime;
            angleRightToReach -= 4 * Time.deltaTime;
        }
        else
        {
            angleLeftToReach += 4 * Time.deltaTime;
            angleRightToReach -= 4 * Time.deltaTime;
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
            angleLeftToReach = -40;
            angleRightToReach = 40;
            currentAngleLeftToReach = -40;
            currentAngleRightToReach = 40;
        }
    }

    private bool IsNear(float a, float b, float error)
    {
        return Mathf.Abs(a - b) < error;
    }
}
