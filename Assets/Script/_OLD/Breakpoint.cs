using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakpoint : MonoBehaviour
{
    public static event Action OnHitted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        //RaycastHit2D hitInfo = Physics2D.Raycast(collision.transform.position, Vector2.down, 5.0f);
        //Debug.DrawRay(collision.transform.position, Vector2.down * 5.0f, Color.blue);

        if(!collision.gameObject.TryGetComponent<Rigidbody2D>(out var rb))
        {
            Debug.LogError("Missing rigidBody");
            return;
        }

        if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var movement))
        {
            Debug.LogError("Missing PlayerMovement");
            return;
        }

        if (!collision.gameObject.TryGetComponent<PlayerInput>(out var input))
        {
            Debug.LogError("Missing PlayerInput");
            return;
        }

        OnHitted?.Invoke();

        //if (collision.gameObject.TryGetComponent<PlayerMovement>(out var movement))
        //{
        //    //movement.uncontrollable = true;
        //    player.hasHitted = true;
        //    OnHitted?.Invoke();
        //    //player.x += (1f - hitNormal.y) * hitNormal.x * (speed - slideFriction);
        //}
    }
}
