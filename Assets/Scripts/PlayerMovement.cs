using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private void OnEnable()
    {
        KeyboardInput.OnAButton += MoveLeft;
        KeyboardInput.OnDButton += MoveRight;
    }

    private void MoveLeft()
    {
        transform.Translate(-Vector2.left * Time.deltaTime * _moveSpeed);
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _moveSpeed);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnDisable()
    {
        KeyboardInput.OnAButton -= MoveLeft;
        KeyboardInput.OnDButton -= MoveRight;
    }
}
