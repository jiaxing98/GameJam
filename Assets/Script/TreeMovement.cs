using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [Range(0f, 1f)]
    [SerializeField] float _procChance = 0.5f;
    [SerializeField] float triggered;
    [SerializeField] float _minJumpForce = 10f;
    [SerializeField] float _maxJumpForce = 40f;
    [SerializeField] float _jumpForce;

    [SerializeField] float _raycastDistance = 3f;
    [SerializeField] LayerMask _layerMask = 1 << 8;
    [SerializeField] bool _isGrounded = false;
    [SerializeField] bool _resetJump = false;
    [SerializeField] bool _notJumping;

    // Start is called before the first frame update
    void Start()
    {
        _jumpForce = Random.Range(_minJumpForce, _maxJumpForce);
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    async void Update()
    {
        if (_isGrounded)
        {
            triggered = Random.Range(0f, 1.0f);
            Debug.Log($"triggered: {triggered}");

            if (triggered >= _procChance && !_notJumping)
            {
                _jumpForce = Random.Range(_minJumpForce, _maxJumpForce);
                _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
                _isGrounded = false;
                _resetJump = true;
                _notJumping = false;
                StartCoroutine(ResetJumpRoutine());
                Debug.Log($"velocity.y: {_rigid.velocity.y}");
            }
            else
            {
                await NotJumping();
            }
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _layerMask.value);
        Debug.DrawRay(transform.position, Vector2.down * _raycastDistance, Color.green);

        if (hitInfo.collider != null)
        {
            //Debug.Log(hitInfo.collider.name);
            if (!_resetJump) _isGrounded = true;
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    private async Task NotJumping()
    {
        await Task.Delay(2000);
    }
}
