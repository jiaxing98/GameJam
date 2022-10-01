using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	[SerializeField] private StartScene _countdown;
	[SerializeField] private EndScene _endScene;
	[SerializeField] private GameObject _tractor;

	private float _tractorSpeed;
	private static GameManager Instance;

	void Awake()
	{
		//If a Game Manager exists and this isn't it...
		if (Instance != null && Instance != this)
		{
			//...destroy this and exit. There can only be one Game Manager
			Destroy(gameObject);
			return;
		}

		//Set this as the current game manager
		Instance = this;

		//Persis this object between scene reloads
		DontDestroyOnLoad(gameObject);
	}

    void Start()
    {
		StartScene.onCountdownFinished += TractorStartMoving;
		Explodepoint.onTractorDestroy += GameOver;

        _tractorSpeed = _tractor.GetComponent<PlayerMovement>().speed;
		_tractor.GetComponent<PlayerMovement>().speed = 0;

		_countdown.StartCountdown();
	}

	private void TractorStartMoving()
    {
		_tractor.GetComponent<PlayerMovement>().speed = _tractorSpeed;
	}

	private void GameOver()
    {
		_endScene.gameObject.SetActive(true);
		_tractor.GetComponent<Player>().enabled = false;
	}
}
