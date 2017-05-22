using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;
    
    public bool isGrounded = true;

    private void OnEnable()
    {
        KeyboardInput.OnAButton += MoveLeft;
        KeyboardInput.OnDButton += MoveRight;
        KeyboardInput.OnSpaceButton += Jump;
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _moveSpeed);
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _moveSpeed);
    }

    private void Jump()
    {
        if(isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnDisable()
    {
        KeyboardInput.OnAButton -= MoveLeft;
        KeyboardInput.OnDButton -= MoveRight;
        KeyboardInput.OnSpaceButton -= Jump;
    }
}