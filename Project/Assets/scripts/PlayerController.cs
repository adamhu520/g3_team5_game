using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private Vector2 _moveDirection;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveDirection = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));
        _moveDirection.x *= moveSpeed;
        _moveDirection.y *= moveSpeed;


        _animator.SetFloat(AnimatorHash.MoveSpeed, Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.y));
    
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(_moveDirection, ForceMode2D.Impulse);
    }
}