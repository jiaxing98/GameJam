using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StartScene : MonoBehaviour
{
    [SerializeField] private GameObject startScenePanel;
    [SerializeField] private TMP_Text _countdownText;

    private int _countdownIndex = 0;
    private List<string> _countdownStrings = new List<string> { "3", "2", "1", "Start!" };

    public static Action onCountdownFinished;

    // Start is called before the first frame update
    void Start()
    {
        _countdownText.text = "";
    }

    public void StartCountdown()
    {
        InvokeRepeating(nameof(Countdown), 1, 1);
    }

    private void Countdown()
    {
        if(_countdownIndex > _countdownStrings.Count - 1)
        {
            onCountdownFinished();
            CancelInvoke();
            startScenePanel.SetActive(false);
            return;
        }

        _countdownText.text = _countdownStrings[_countdownIndex];
        _countdownIndex++;
    }
}
