using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 10f;

    public bool uncontrollable = false;
    public float cacheX = -0.5f;

    public SoundManager soundManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        soundManager.Play(SoundType.Move);
    }

    // Update is called once per frame
    void Update()
    {
        if (uncontrollable)
        {
            cacheX = Mathf.Clamp(cacheX += -1f, -6f, 0f);
            rigid.velocity = new Vector2(cacheX, rigid.velocity.y);
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal") * runSpeed;
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundManager.Play(SoundType.Jump);
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
        }
    }
}
