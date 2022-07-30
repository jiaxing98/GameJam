using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _strength;
    [SerializeField] private float _duration;

    private float _initialSpeed;
    public static event Action<Transform> OnHitted;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(Settings.Tag.PLAYER)) return;
        if (!collision.gameObject.TryGetComponent<Rigidbody2D>(out var rb)) return;
        if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var movement)) return;

        Debug.Log($"Obstacle is hitted by {collision.gameObject.name}");
        Debug.Log($"collision: {collision.transform.position}");
        Debug.Log($"transform: {transform.position}");

        _initialSpeed = movement.speed;
        Vector2 direction = collision.transform.position - transform.position;
        direction.y = 0;
        Debug.Log($"direction: {direction.normalized}");
        rb.AddForce(direction.normalized * _strength, ForceMode2D.Impulse);

        OnHitted?.Invoke(transform);
    }
}
