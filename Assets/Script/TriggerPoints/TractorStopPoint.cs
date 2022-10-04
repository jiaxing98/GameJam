using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorStopPoint : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] private float _bgmFadingOutDuration;

    [Header("Flood")]
    [SerializeField] private Transform _floodTransform;
    [SerializeField] private float _waterLevelStop;
    [SerializeField] private float _risingDuration;

    [Header("Cloud")]
    [SerializeField] private Transform _cloudTransform1;
    [SerializeField] private Transform _cloudTransform2;
    [SerializeField] private float _destinationX1;
    [SerializeField] private float _destinationX2;
    [SerializeField] private float _movingDuration;

    [Header("Rain")]
    [SerializeField] private List<ParticleSystem> _rainParticles;
    [SerializeField] private float _rainingInterval;

    [Header("Fire")]
    [SerializeField] private SpriteRenderer _fireSpriteRenderer;
    [SerializeField] private float _fadeOutDuration;

    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;
    private float _tractorSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<PlayerMovement>(out var playerMovement)) return;
        if (!collision.gameObject.TryGetComponent<PlayerInput>(out var playerInput)) return;

        _playerMovement = playerMovement;
        _playerInput = playerInput;

        _tractorSpeed = playerMovement.speed;
        playerMovement.speed = 0;
        playerInput.stopActing = true;
        StartAnimationSequence();
    }

    private void StartAnimationSequence()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendCallback(() => SoundManager.Instance.BGMFading(0f, _bgmFadingOutDuration))
            .AppendCallback(CloudMoving)
            .AppendCallback(() => _rainParticles.ForEach(x => x.Play()))
            .AppendInterval(_rainingInterval)
            .Append(_fireSpriteRenderer.DOFade(0.0f, _fadeOutDuration))
            .Append(_floodTransform.DOMoveY(_waterLevelStop, _risingDuration))
            .AppendCallback(TractorStartMoving);
    }

    private void CloudMoving()
    {
        _cloudTransform1.DOMoveX(_destinationX1, _movingDuration);
        _cloudTransform2.DOMoveX(_destinationX2, _movingDuration);
    }

    private void TractorStartMoving()
    {
        _playerMovement.speed = _tractorSpeed;
        _playerInput.stopActing = false;
    }
}
