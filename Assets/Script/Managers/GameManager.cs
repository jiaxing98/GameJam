using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	[SerializeField] private StartScene _countdown;
	[SerializeField] private EndScene _endScene;
	[SerializeField] private GameObject _tractor;

	private float _tractorSpeed;

    void Start()
    {
		StartScene.onCountdownFinished += TractorStartMoving;
		Explodepoint.onTractorDestroy += GameOver;

        _tractorSpeed = _tractor.GetComponent<PlayerMovement>().speed;
		_tractor.GetComponent<PlayerMovement>().speed = 0;

		_countdown.StartCountdown();
	}

    private void OnDestroy()
    {
		StartScene.onCountdownFinished -= TractorStartMoving;
		Explodepoint.onTractorDestroy -= GameOver;
	}

    private void TractorStartMoving()
    {
		_tractor.GetComponent<PlayerMovement>().speed = _tractorSpeed;
	}

	private void GameOver()
    {
		_endScene.gameObject.SetActive(true);
		_tractor.GetComponent<Player>().enabled = false;
		SoundManager.Instance.StopPlayingSfx(Settings.SfxType.Tractor);
		SoundManager.Instance.PlayBGM(Settings.SoundType.BGMEnd);
	}
}
