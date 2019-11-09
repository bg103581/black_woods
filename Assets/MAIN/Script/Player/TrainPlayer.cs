using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrainPlayer : MonoBehaviour
{
    Vector3 move;
    [SerializeField]
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }

    void OnMovement(InputValue value) {
        Debug.Log("moving");
        move = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
    }
}
