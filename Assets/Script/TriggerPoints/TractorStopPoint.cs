using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorStopPoint : MonoBehaviour
{
    [SerializeField] private Transform _floodTransform;
    [SerializeField] private float _risingDuration;
    [SerializeField] private float _waterLevelStop;

    [SerializeField] private SpriteRenderer _fireSpriteRenderer;
    [SerializeField] private float _fadeOutDuration;

    private PlayerMovement _playerMovement;
    private float _tractorSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var playerMovement)) return;

        _playerMovement = playerMovement;
        _tractorSpeed = playerMovement.speed;
        playerMovement.speed = 0;
        StartAnimationSequence();
    }

    private void StartAnimationSequence()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_fireSpriteRenderer.DOFade(0.0f, _fadeOutDuration))
            .Append(_floodTransform.DOMoveY(_waterLevelStop, _risingDuration))
            .AppendCallback(TractorStartMoving);
    }

    private void TractorStartMoving()
    {
        _playerMovement.speed = _tractorSpeed;
    }
}
