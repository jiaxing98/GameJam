using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _hasFinished = false;
    [SerializeField] private bool _readyToGameScene = false;

    [Header("Assignment")]
    [SerializeField] private string _playerName = "";
    [SerializeField] private Text _introText;
    [SerializeField] private InputField _inputField;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private GameObject _blocker;
    [SerializeField] private List<Sprite> _sprites;

    private int _dialogIndex = 0;
    private List<string> _texts = new List<string>
    {
        "Hi there, how may I help you?",
        "Ah yes, you must be the new tractor operator!",
        "Please type your name down here and \nwe will process the papers for you shortly",
        "Hi _name, nice to meet you! \nHere is your license and tractor key",
        "Now go out there are cut down those trees! \nFor the development of mankind!!!",
        "Controls: \nPress ‘Spacebar’ to jump over obstacles!"
    };

    private const string GAME_SCENE = "In-Game";
    private const float SHORT_TEXTS = 3f;
    private const float LONG_TEXTS = 6f;

    // Start is called before the first frame update
    void Start()
    {
        _introText.text = "";
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(interval: 1f)
            .AppendCallback(() => { ShowNextDialog(SHORT_TEXTS); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _readyToGameScene)
        {
            SceneManager.LoadScene(GAME_SCENE);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _hasFinished)
        {
            if (_dialogIndex >= _texts.Count) return;

            //Display background images
            if (_dialogIndex == 2)
            {
                _inputField.gameObject.SetActive(true);
                _backgroundImage.sprite = _sprites[0];
            }
            else if (_dialogIndex == 3)
            {
                _playerName = _inputField.text;
                _inputField.gameObject.SetActive(false);

                _backgroundImage.sprite = _sprites[1];
                _texts[_dialogIndex] = _texts[_dialogIndex].Replace("_name", _playerName);
            }
            else if (_dialogIndex == _texts.Count - 1)
                _backgroundImage.sprite = _sprites[2];

            //Display dialogs
            if (_dialogIndex < 2 || _dialogIndex == _texts.Count - 1)
                ShowNextDialog(SHORT_TEXTS);
            else if (_dialogIndex == 2)
                ShowNextDialog(LONG_TEXTS, false);
            else
                ShowNextDialog(LONG_TEXTS);
        }
    }

    private void ShowNextDialog(float duration, bool showBlocker = true)
    {
        _hasFinished = false;
        _blocker.SetActive(showBlocker);
        _introText.text = "";

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(_introText.DOText(_texts[_dialogIndex], duration))
            .AppendCallback(() =>
            {
                _blocker.SetActive(false);
                _dialogIndex++;
                _hasFinished = true;

                if (_dialogIndex == _texts.Count) 
                    _readyToGameScene = true;
            });
    }
}
