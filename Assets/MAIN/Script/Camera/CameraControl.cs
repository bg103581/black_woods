using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject _dots;
    private GameObject _strix;

    //[HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public bool isZooming;
    [HideInInspector]
    public Vector3 offSetCoop;
    [HideInInspector]
    public Vector3 offSetStrixLastUpdatePos;

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
    void Start()
    {
        isMoving = true;
        Physics.IgnoreLayerCollision(_playerLayer, _playerLayer, true);

        _dots = GameObject.Find("Dots");
        _strix = GameObject.Find("Strix");

        _minPosZ = transform.position.z;
        _posXY = new Vector2((_dots.transform.position.x + _strix.transform.position.x)/2, (_dots.transform.position.y + _strix.transform.position.y)/2);
        _pos = new Vector3(_posXY.x, _posXY.y, _minPosZ);

        transform.position = _pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            transform.position = UpdatePosition();
        }
        else {
            transform.position = _strix.transform.position + offSetStrixLastUpdatePos + offSetCoop;
        }

        IsToFar = _distanceDiffPlayers >= _maxDistPlayers;
        _strix.GetComponent<Player>().IsLeft = _strix.transform.position.x < _dots.transform.position.x;
        _dots.GetComponent<Player>().IsLeft = _dots.transform.position.x < _strix.transform.position.x;
    }

    public Vector3 UpdatePosition() {
        _posXY = new Vector2((_dots.transform.position.x + _strix.transform.position.x) / 2, (_dots.transform.position.y + _strix.transform.position.y) / 2);
        _distanceDiffPlayers = Vector2.Distance(_dots.transform.position, _strix.transform.position);

        //transform.LookAt(new Vector3(_posXY.x, _posXY.y, _strix.transform.position.z));

        return new Vector3(_posXY.x, _posXY.y + _offSetY, Mathf.Lerp(_minPosZ, _maxPosZ, Mathf.Clamp01((_distanceDiffPlayers - _offSetDist) * _scale)));
    }
}
