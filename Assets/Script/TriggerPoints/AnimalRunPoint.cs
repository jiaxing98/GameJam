using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRunPoint : MonoBehaviour
{
    [SerializeField] private Transform _animalTransform;
    [SerializeField] private float _destinationX;
    [SerializeField] private float _runningDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.TryGetComponent<Player>(out var player)) return;
        StartAnimationSequence();
    }

    private void StartAnimationSequence()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_animalTransform.DOMoveX(_destinationX, _runningDuration));
    }
}
