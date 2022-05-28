using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakpoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        RaycastHit2D hitInfo = Physics2D.Raycast(collision.transform.position, Vector2.down, 5.0f);
        var normal = hitInfo.normal;
        player.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        Debug.DrawRay(collision.transform.position, Vector2.down * 5.0f, Color.blue);

        if (collision.gameObject.TryGetComponent<PlayerMovement>(out var movement))
        {
            movement.uncontrollable = true;
            int loop = 0;
            while (loop < 5)
            {
                movement.LostControl();
                Debug.Log($"x velo: {movement.GetXVelocity()}");
                loop++;
            }

            //player.x += (1f - hitNormal.y) * hitNormal.x * (speed - slideFriction);
        }
    }
}
