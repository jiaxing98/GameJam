// This script is a Manager that controls the UI HUD (deaths, time, and orbs) for the 
// project. All HUD UI commands are issued through the static methods of this class

using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	//This class holds a static reference to itself to ensure that there will only be
	//one in existence. This is often referred to as a "singleton" design pattern. Other
	//scripts access this one through its public static methods
	static UIManager Instance;

	public TextMeshProUGUI timeText;        //Text element showing amount of time
	public TextMeshProUGUI deathText;       //Text element showing number or deaths
	public TextMeshProUGUI gameOverText;    //Text element showing the Game Over message


	void Awake()
	{
		//If an UIManager exists and it is not this...
		if (Instance != null && Instance != this)
		{
			//...destroy this and exit. There can be only one UIManager
			Destroy(gameObject);
			return;
		}

		//This is the current UIManager and it should persist between scene loads
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public static void UpdateTimeUI(float time)
	{
		//If there is no current UIManager, exit
		if (Instance == null) return;

		//Take the time and convert it into the number of minutes and seconds
		int minutes = (int)(time / 60);
		float seconds = time % 60f;

		//Create the string in the appropriate format for the time
		Instance.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
	}

	public static void UpdateDeathUI(int deathCount)
	{
		//If there is no current UIManager, exit
		if (Instance == null) return;

		//update the player death count element
		Instance.deathText.text = deathCount.ToString();
	}

	public static void DisplayGameOverText()
	{
		//If there is no current UIManager, exit
		if (Instance == null) return;

		//Show the game over text
		Instance.gameOverText.enabled = true;
	}
}
