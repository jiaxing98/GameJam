using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EndScene : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private Color _panelColor;
    [SerializeField] private float _panelFadeInDuration;
    private Image _panelImage;

    [Header("Quote")]
    [SerializeField] private TMP_Text _quote;
    [SerializeField] private float _quoteFadeInDuration;
    [SerializeField] private float _quoteFadeOutDuration;

    [Header("Credits")]
    [SerializeField] private Transform _creditsTransform;
    [SerializeField] private float _destinationY;
    [SerializeField] private float _creditsFadeOutDuration;

    // Start is called before the first frame update
    void Start()
    {
        _panelImage = GetComponent<Image>();
        if (_panelImage == null) return;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_panelImage.DOColor(_panelColor, _panelFadeInDuration))
            .Append(_quote.DOFade(1.0f, _quoteFadeInDuration))
            .Append(_quote.DOFade(0.0f, _quoteFadeOutDuration))
            .Append(_creditsTransform.DOMoveY(_destinationY, _creditsFadeOutDuration));
    }
}
