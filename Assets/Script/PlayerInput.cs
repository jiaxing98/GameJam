// This script handles inputs for the player. It serves two main purposes: 1) wrap up
// inputs so swapping between mobile and standalone is simpler and 2) keeping inputs
// from Update() in sync with FixedUpdate()

using System.Threading.Tasks;
using UnityEngine;

//We first ensure this script runs before all other player scripts to prevent laggy
//inputs
[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
	public float horizontal;      //Float that stores horizontal input
	public bool jumpHeld;         //Bool that stores jump pressed
	public bool jumpPressed;      //Bool that stores jump held
	
	public float interval;
	[Range(0, 1)] public float inputValue;

	private bool readyToClear;            //Bool used to keep input in sync
	private float timer;

	void Update()
	{
		//Clear out existing input values
		ClearInput();

		//If the Game Manager says the game is over, exit
		if (GameManager.IsGameOver()) return;

		//Process keyboard, mouse, gamepad (etc) inputs
		ProcessInputs();

		//Clamp the horizontal input to be between -1 and 1
		horizontal = Mathf.Clamp(horizontal, -1f, 1f);
	}

	void FixedUpdate()
	{
		//In FixedUpdate() we set a flag that lets inputs to be cleared out during the 
		//next Update(). This ensures that all code gets to use the current inputs
		readyToClear = true;
	}

	void ClearInput()
	{
		//If we're not ready to clear input, exit
		if (!readyToClear) return;

		//Reset all inputs
		horizontal = 0f;
		jumpPressed = false;
		jumpHeld = false;

		readyToClear = false;
	}

	void ProcessInputs()
	{
		//Accumulate horizontal axis input
		//horizontal += Input.GetAxis("Horizontal");
		horizontal += Acceleration();


		//Accumulate button inputs
		jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
		jumpHeld = jumpHeld || Input.GetButton("Jump");
	}

	float Acceleration()
    {
		timer += Time.deltaTime;
		if(timer >= interval)
        {
			inputValue = Mathf.Clamp(inputValue + 5 * Time.deltaTime, -1, 1);
			timer = 0f;
		}
		return inputValue;
	}
}