using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    [Header("Jump")]
    public Transform feetPos;
    public float checkRadius;
    public float jumpTime;
    public LayerMask groundLayer;

    private float _moveInput;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _jumpTimeCounter;
    private bool _isJumping;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        string horizontal = "Horizontal";
        _moveInput = Input.GetAxisRaw(horizontal);
        _rb.velocity = new Vector2(_moveInput * moveSpeed, _rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        if (_moveInput > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);        
        else       
            transform.eulerAngles = new Vector3(0, 180, 0);       
    }

    private void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, groundLayer);

        if (_isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && _isJumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) _isJumping = false;
    }
}
