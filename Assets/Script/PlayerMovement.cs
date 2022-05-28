using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;
    [SerializeField] float _runSpeed = 10f;
    [SerializeField] float _jumpForce = 10f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float _lowJumpMultiplier = 2f;

    [SerializeField] float _raycastDistance = 3f;
    [SerializeField] LayerMask _layerMask = 1 << 8;
    [SerializeField] bool _isGrounded = false;
    [SerializeField] bool _resetJump = false;

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

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _isGrounded = false;
            _resetJump = true;
            StartCoroutine(ResetJumpRoutine());
            Debug.Log($"velocity.y: {_rigid.velocity.y}");
        }

        //if (_rigid.velocity.y < 0)
        //{
        //    _rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (_rigid.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        //{
        //    _rigid.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _layerMask.value);
        Debug.DrawRay(transform.position, Vector2.down * _raycastDistance, Color.green);

        if (hitInfo.collider != null)
        {
            //Debug.Log(hitInfo.collider.name);
            if(!_resetJump) _isGrounded = true;
        }
    }
    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
