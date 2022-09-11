using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRunPoint : MonoBehaviour
{
    public static event Action OnAnimalStartRunning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        OnAnimalStartRunning?.Invoke();
    }
}
