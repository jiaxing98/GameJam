using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float lowJumpMultiplier = 2f;

    [SerializeField] float raycastDistance = 3f;
    [SerializeField] LayerMask layerMask = 1 << 8;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool resetJump = false;

    public bool uncontrollable = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (horizontalInput != 0) Move();
        if (uncontrollable) return;

        float horizontalInput = Input.GetAxis("Horizontal") * runSpeed;
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            isGrounded = false;
            resetJump = true;
            StartCoroutine(ResetJumpRoutine());
            Debug.Log($"velocity.y: {rigid.velocity.y}");
        }

        //if (_rigid.velocity.y < 0)
        //{
        //    _rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if (_rigid.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        //{
        //    _rigid.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, layerMask.value);
        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.green);

        if (hitInfo.collider != null)
        {
            //Debug.Log(hitInfo.collider.name);
            if(!resetJump) isGrounded = true;
        }
    }

    public void LostControl()
    {
        rigid.velocity += new Vector2(10f * Time.deltaTime, rigid.velocity.y);
    }

    public float GetXVelocity()
    {
        return rigid.velocity.x;
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
