using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorStopPoint : MonoBehaviour
{
    public static event Action OnTractorStops;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var playerMovement)) return;
        playerMovement.speed = 0;
        OnTractorStops?.Invoke();
    }
}
