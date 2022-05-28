using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodepoint : MonoBehaviour
{
    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        Breakpoint.OnHitted += OffTriggered;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        if (player.hasHitted) Destroy(player.gameObject);
    }

    public void OffTriggered()
    {
        box.isTrigger = false;
    }
}
