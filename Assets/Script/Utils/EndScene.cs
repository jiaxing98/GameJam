using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

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

    [Header("Back To Menu")]
    [SerializeField] private GameObject _backToMenuGO;
    [SerializeField] private TMP_Text _backToMenu;
    [SerializeField] private float _backToMenuFadeInDuration;

    private bool _readyBackToMenu = false;
    private const string MAINMENU_SCENE = "Main Menu";

    // Start is called before the first frame update
    void Start()
    {
        _panelImage = GetComponent<Image>();
        if (_panelImage == null) return;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_panelImage.DOColor(_panelColor, _panelFadeInDuration))
            .Append(_quote.DOFade(1.0f, _quoteFadeInDuration))
            .Append(_quote.DOFade(0.0f, _quoteFadeOutDuration))
            .Append(_creditsTransform.DOMoveY(_destinationY, _creditsFadeOutDuration))
            .AppendCallback(async () => { 
                _backToMenuGO.SetActive(true);
                await _backToMenu.DOFade(1.0f, _backToMenuFadeInDuration).AsyncWaitForCompletion();
                _readyBackToMenu = true;
            });
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _readyBackToMenu)
        {
            SceneManager.LoadScene(MAINMENU_SCENE);
        }
    }
}
