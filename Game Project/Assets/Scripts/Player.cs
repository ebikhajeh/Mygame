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

    public float startx, starty;
    public GameObject Blood;

    // Start is called before the first frame update
    void Start()
    {
        startx = _visual.transform.position.x;
        starty = _visual.transform.position.y;
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

    public void Death()
    {
        StartCoroutine("respawndelay");
    }

    public IEnumerator respawndelay()
    {
        Instantiate(Blood, transform.position, transform.rotation);
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0);
        transform.position = new Vector2(startx, starty);
        GetComponent<Renderer>().enabled = true;
        enabled = true;
    }


}
