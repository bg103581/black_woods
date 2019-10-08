using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strix : Player
{
    private void Awake() {
        Init();

        _controls.Player.StrixMovement.performed += ctx => _move = new Vector2(ctx.ReadValue<float>(), 0);
        _controls.Player.StrixMovement.canceled += ctx => _move = Vector2.zero;

        _controls.Player.StrixJump.performed += ctx => Jump();
    }

    private void Update() {
        Vector2 m = new Vector2(_move.x, _move.y) * Time.deltaTime * _playerSpeed;
        transform.Translate(m, Space.World);
    }
}
