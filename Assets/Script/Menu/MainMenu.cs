using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool _isGameStart = false;
    private const string INTRO_SCENE = "Intro";

    private void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGameStart) 
            SceneManager.LoadScene(INTRO_SCENE);
    }

    private async void GameStart()
    {
        SoundManager.Instance.StopPlayingAll();
        SoundManager.Instance.PlayBGM(Settings.SoundType.BGMStart);
        await Task.Delay(2000);
        _isGameStart = true;
    }
}
