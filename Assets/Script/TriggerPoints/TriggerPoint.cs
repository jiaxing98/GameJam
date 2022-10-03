using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public static Action onTractorPassed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        onTractorPassed?.Invoke();
    }
}
