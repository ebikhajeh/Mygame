using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _visual;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public int fruits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement(horizontal);
        Animation(horizontal);

    }
    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    public void Movement(float horizontal)
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
        transform.position += new Vector3(_movementSpeed, 0, 0) * horizontal * Time.deltaTime;
    }
    public void Animation(float horizontal)
    {
        _animator.SetFloat("MovementSpeed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            _visual.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            _visual.transform.localScale = new Vector3(-1, 1, 1);
        }
    }


}
