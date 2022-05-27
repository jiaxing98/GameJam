using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] float _runSpeed = 40f;
    [SerializeField] float _jumpForce = 5.0f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float _lowJumpMultiplier = 2f;

    //[SerializeField] float horizontalInput;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (horizontalInput != 0) Move();

        float horizontalInput = Input.GetAxis("Horizontal") * _runSpeed;
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigid.velocity = Vector2.up * _jumpForce;

            if (_rigid.velocity.y < 0)
            {
                _rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                Debug.Log("fall");
            }
            else if (_rigid.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                _rigid.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
                Debug.Log("low jump");
            }
        }
    }

    private void Jump()
    {

    }

    private void Move()
    {
    }
}
