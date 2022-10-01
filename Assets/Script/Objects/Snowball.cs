using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;

    public static event Action OnHitted;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();

        Explodepoint.onTractorPassed += AddRigidBody;
    }

    private void AddRigidBody()
    {
        _rigidbody = this.gameObject.AddComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        OnHitted?.Invoke();
    }
}
