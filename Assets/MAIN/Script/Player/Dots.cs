using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : Player
{
    private void Awake() {
        Init();

        _controls.Player.DotsMovement.performed += ctx => _move = new Vector2(ctx.ReadValue<float>(), 0);
        _controls.Player.DotsMovement.canceled += ctx => _move = Vector2.zero;

        _controls.Player.DotsJump.performed += ctx => Jump();
    }

    private void Update() {
        PlayerUpdate();
    }
}
