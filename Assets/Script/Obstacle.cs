using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _duration;

    public static event Action<Transform> OnHitted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (!collision.gameObject.CompareTag(Settings.Tag.PLAYER)) return;
        //if (!collision.gameObject.TryGetComponent<Rigidbody2D>(out var rb)) return;
        //if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var movement)) return;

        //Debug.Log($"Obstacle is hitted by {collision.gameObject.name}");
        //Debug.Log($"collision: {collision.transform.position}");
        //Debug.Log($"transform: {transform.position}");

        //movement.gotKnockedback = true;
        //Vector2 direction = collision.transform.position - transform.position;
        //Debug.Log($"direction: {direction.normalized}");
        //rb.AddForce(new Vector2(direction.normalized.x * _force, 0f), ForceMode2D.Impulse);
        //await Task.Delay(1500);

        OnHitted?.Invoke(transform);
    }
}
