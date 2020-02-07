using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraControl : MonoBehaviour
{
    private GameObject _dots;
    private GameObject _strix;

    public bool isMoving;   //true when coop
    [HideInInspector]
    public bool isZooming;  //true when not in foreground trigger
    [HideInInspector]
    public Vector3 offSetCoop;
    [HideInInspector]
    public Vector3 offSetStrixLastUpdatePos;
    [HideInInspector]
    public bool isSmoothingToZ; //true when need to smooth z position (isZooming = false -> true)
    [SerializeField]
    private float smoothScale;
    [SerializeField]
    private float epsilon;

    [SerializeField]
    [Range(0, 31)] private int _playerLayer;

    public float _minPosZ;
    [Space(10f)]
    [SerializeField]
    private float _maxPosZ;
    private Vector2 _posXY;
    private float _distanceDiffPlayers;
    private Vector3 _pos;

    [SerializeField]
    private float _offSetDist;
    [SerializeField]
    private float _scale;
    [SerializeField]
    private float _offSetY;

    [Space(10f)]
    [SerializeField]
    private float _maxDistPlayers = 100f;
    public bool IsToFar;

    // Start is called before the first frame update
    void Start() {
        isMoving = true;
        isZooming = true;
        Physics.IgnoreLayerCollision(_playerLayer, _playerLayer, true);

        _dots = GameObject.Find("Dots");
        _strix = GameObject.Find("Strix");

        _minPosZ = transform.position.z;
        _posXY = new Vector2((_dots.transform.position.x + _strix.transform.position.x) / 2, (_dots.transform.position.y + _strix.transform.position.y) / 2);
        _pos = new Vector3(_posXY.x, _posXY.y, _minPosZ);

        transform.position = _pos;
    }

    // Update is called once per frame
    void Update() {
        if (isMoving) {
            if (isZooming) {
                if (!isSmoothingToZ) {
                    transform.position = UpdatePosition();
                }
            }
            else {
                transform.position = new Vector3(_posXY.x, _posXY.y + _offSetY, transform.position.z);
            }
        }
        else {
            if (isZooming) {
                if (!isSmoothingToZ) {
                    transform.position = new Vector3(
                        _strix.transform.position.x + offSetStrixLastUpdatePos.x + offSetCoop.x,
                        _strix.transform.position.y + offSetStrixLastUpdatePos.y + offSetCoop.y,
                        transform.position.z);
                }
            }
            else {
                transform.position = new Vector3(
                    _strix.transform.position.x + offSetStrixLastUpdatePos.x + offSetCoop.x,
                    _strix.transform.position.y + offSetStrixLastUpdatePos.y + offSetCoop.y,
                    transform.position.z);
            }
        }

        _posXY = new Vector2((_dots.transform.position.x + _strix.transform.position.x) / 2, (_dots.transform.position.y + _strix.transform.position.y) / 2);
        _distanceDiffPlayers = Vector2.Distance(_dots.transform.position, _strix.transform.position);
        IsToFar = _distanceDiffPlayers >= _maxDistPlayers;
        _strix.GetComponent<Player>().IsLeft = _strix.transform.position.x < _dots.transform.position.x;
        _dots.GetComponent<Player>().IsLeft = _dots.transform.position.x < _strix.transform.position.x;

        isSmoothingToZ = Mathf.Abs(transform.position.z - Mathf.Lerp(_minPosZ, _maxPosZ, Mathf.Clamp01((_distanceDiffPlayers - _offSetDist) * _scale))) > epsilon;
    }

    private void LateUpdate() {    //to smooth z pos of camera
        if (isMoving) {
            if (isZooming) {
                if (isSmoothingToZ) {
                    transform.position = FixedUpdatePosition();
                }
            }
        }
        else {
            if (isZooming) {
                if (isSmoothingToZ) {
                    transform.position = new Vector3(
                        _strix.transform.position.x + offSetStrixLastUpdatePos.x + offSetCoop.x,
                        _strix.transform.position.y + offSetStrixLastUpdatePos.y + offSetCoop.y,
                        SmoothToZCoop());
                }
            }
        }
    }

    private float SmoothToZCoop() {
        float desiredZ = _minPosZ;
        float smoothedZ = Mathf.Lerp(transform.position.z, desiredZ, smoothScale * Time.deltaTime);
        return smoothedZ;
    }

    private float SmoothToZ() {
        float desiredZ = Mathf.Lerp(_minPosZ, _maxPosZ, Mathf.Clamp01((_distanceDiffPlayers - _offSetDist) * _scale));
        float smoothedZ = Mathf.Lerp(transform.position.z, desiredZ, smoothScale * Time.deltaTime);
        return smoothedZ;
    }

    public Vector3 FixedUpdatePosition() {
        return new Vector3(_posXY.x, _posXY.y + _offSetY, SmoothToZ());
    }

    public Vector3 UpdatePosition() {
        float z;
        z = Mathf.Lerp(_minPosZ, _maxPosZ, Mathf.Clamp01((_distanceDiffPlayers - _offSetDist) * _scale));
        return new Vector3(_posXY.x, _posXY.y + _offSetY, z);
    }

    public void MoveToMaxZ(float duration) {
        transform.DOMoveZ(_maxPosZ, duration);
    }
}
