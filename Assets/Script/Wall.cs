using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private BoxCollider2D box;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var actor)) return;
        if (!actor.hasDestroyed) box.isTrigger = true;
    }
}
