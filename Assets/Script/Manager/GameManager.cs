// This script is a Manager that controls the the flow and control of the game. It keeps
// track of player data (orb count, death count, total game time) and interfaces with
// the UI Manager. All game commands are issued through the static methods of this class

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	static GameManager Instance;

	public float deathSequenceDuration = 1.5f;  //How long player death takes before restarting

	int numberOfDeaths;                         //Number of times player has died
	float totalGameTime;                        //Length of the total game time
	bool isGameOver;                            //Is the game currently over?


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

	void Update()
	{
		//If the game is over, exit
		if (isGameOver) return;

		//Update the total game time and tell the UI Manager to update
		totalGameTime += Time.deltaTime;
		//UIManager.UpdateTimeUI(totalGameTime);
	}

	public static bool IsGameOver()
	{
		//If there is no current Game Manager, return false
		if (Instance == null) return false;

		//Return the state of the game
		return Instance.isGameOver;
	}

	//public static void RegisterSceneFader(SceneFader fader)
	//{
	//	//If there is no current Game Manager, exit
	//	if (Instance == null) return;

	//	//Record the scene fader reference
	//	Instance.sceneFader = fader;
	//}

	public static void PlayerDied()
	{
		//If there is no current Game Manager, exit
		if (Instance == null) return;

		//Increment the number of player deaths and tell the UIManager
		Instance.numberOfDeaths++;
		//UIManager.UpdateDeathUI(Instance.numberOfDeaths);

		//If we have a scene fader, tell it to fade the scene out
		//if (Instance.sceneFader != null)
		//	Instance.sceneFader.FadeSceneOut();

		//Invoke the RestartScene() method after a delay
		Instance.Invoke(nameof(RestartScene), Instance.deathSequenceDuration);
	}

	public static void PlayerWon()
	{
		//If there is no current Game Manager, exit
		if (Instance == null) return;

		//The game is now over
		Instance.isGameOver = true;

		//Tell UI Manager to show the game over text and tell the Audio Manager to play
		//game over audio
		//UIManager.DisplayGameOverText();
		//AudioManager.PlayWonAudio();
	}

	void RestartScene()
	{
		//Play the scene restart audio
		//AudioManager.PlaySceneRestartAudio();

		//Reload the current scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
