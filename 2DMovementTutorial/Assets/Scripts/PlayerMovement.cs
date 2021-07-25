using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement _movement;
    private float _horizontalInput;
    private bool _isJumpPressed;
    
    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void ProcessInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            _isJumpPressed = true;
    }

    private void Move()
    {
        _movement.Move(_horizontalInput);
    }

    private void Jump()
    {
        if (_isJumpPressed)
        {
            _movement.Jump();
            _isJumpPressed = false;
        }
    }
    
}
