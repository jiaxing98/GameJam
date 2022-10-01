using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explodepoint : MonoBehaviour
{
    [Header("EndScene")]
    [SerializeField] private GameObject _panel;

    [Header("Old")]
    public SoundManager soundManager;
    private BoxCollider2D box;

    private bool _isSnowballPassed = false;

    public static Action onTractorPassed;
    public static Action onTractorDestroy;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Snowball>(out var snowball))
            _isSnowballPassed = true;

        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        
        if (_isSnowballPassed)
        {
            box.isTrigger = false;
            onTractorDestroy?.Invoke();
        }
        else
        {
            onTractorPassed?.Invoke();
        }
    }
}
