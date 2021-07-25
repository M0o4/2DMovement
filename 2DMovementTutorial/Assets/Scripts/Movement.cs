using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    
    [Header("Movement settings")]
    [SerializeField] private float _speed;
    [SerializeField] private bool _isFacingRightAtStart;
    private bool _isFacingRight;
    
    [Header("Jump settings")]
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _jumpForce;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        _isFacingRight = _isFacingRightAtStart;
    }

    public void Move(float horizontal)
    {
        _rb2d.velocity = new Vector2(horizontal * _speed * Time.fixedDeltaTime, _rb2d.velocity.y);
        
        if(horizontal > 0 && !_isFacingRight)
            Flip();
        else if(horizontal < 0 && _isFacingRight)
            Flip();
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f,180f,0f);
    }

    public void Jump()
    {
        if(IsGrounded())
            _rb2d.velocity = Vector2.up * _jumpForce;
    }

    private bool IsGrounded() => Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _whatIsGround);

    private void OnDrawGizmos()
    {
        if(_groundCheckPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheckPoint.position, _groundCheckRadius);
    }
}
