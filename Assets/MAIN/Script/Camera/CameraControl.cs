using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject _dots;
    private GameObject _strix;

    [SerializeField]
    [Range(0, 31)] private int _playerLayer;
    
    private float _minPosZ;
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
    [HideInInspector]
    public bool IsToFar;

    // Start is called before the first frame update
    void Start()
    {
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
        transform.position = UpdatePosition();

        IsToFar = _distanceDiffPlayers >= _maxDistPlayers;
        _strix.GetComponent<Player>().IsLeft = _strix.transform.position.x < _dots.transform.position.x;
        _dots.GetComponent<Player>().IsLeft = _dots.transform.position.x < _strix.transform.position.x;
    }

    private Vector3 UpdatePosition() {
        _posXY = new Vector2((_dots.transform.position.x + _strix.transform.position.x) / 2, (_dots.transform.position.y + _strix.transform.position.y) / 2);
        _distanceDiffPlayers = Vector2.Distance(_dots.transform.position, _strix.transform.position);

        return new Vector3(_posXY.x, _posXY.y + _offSetY, Mathf.Lerp(_minPosZ, _maxPosZ, Mathf.Clamp01((_distanceDiffPlayers - _offSetDist) * _scale)));
    }
}
