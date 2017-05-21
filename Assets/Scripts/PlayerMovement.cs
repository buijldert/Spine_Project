using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    public bool isGrounded = true;

    private PlayAnimations _playAnimations;

    private void OnEnable()
    {
        KeyboardInput.OnAButton += MoveLeft;
        KeyboardInput.OnDButton += MoveRight;
        _playAnimations = GetComponent<PlayAnimations>();
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
        _playAnimations._headSkeleton.skeleton.FlipX = true;
        _playAnimations._bodySkeleton.skeleton.FlipX = true;
        _playAnimations._leftArmSkeleton.skeleton.FlipX = true;
        _playAnimations._rightArmSkeleton.skeleton.FlipX = true;
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _moveSpeed);
        _playAnimations._headSkeleton.skeleton.FlipX = false;
        _playAnimations._bodySkeleton.skeleton.FlipX = false;
        _playAnimations._leftArmSkeleton.skeleton.FlipX = false;
        _playAnimations._rightArmSkeleton.skeleton.FlipX = false;
    }

    private void Jump()
    {
        //GetComponent<Rigidbody2D>().AddForce()
    }

    private void OnDisable()
    {
        KeyboardInput.OnAButton -= MoveLeft;
        KeyboardInput.OnDButton -= MoveRight;
    }
}
