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
	[Header("Status Check")]
	public float horizontal;		//Float that stores horizontal input
	public bool jumpHeld;			//Bool that stores jump pressed
	public bool jumpPressed;		//Bool that stores jump held
	public bool isFalling = false;
	public bool stopActing = false;

	[Header("Tweak Value")]
	public float interval;
	public float velocityPerSecond;
	public float inputValue = 0.3f;

	private bool readyToClear;            //Bool used to keep input in sync
	private float timer;

	private float _initialVelocityPerSecond;
	private float _initialInputValue;

    private void Start()
    {
		_initialVelocityPerSecond = velocityPerSecond;
		_initialInputValue = inputValue;

		Breakpoint.OnHitted += PlayerFalling;
    }

    private void OnDestroy()
    {
		Breakpoint.OnHitted -= PlayerFalling;
    }

    private void Update()
	{
		//Clear out existing input values
		ClearInput();

		//Process keyboard, mouse, gamepad (etc) inputs
		ProcessInputs();

		//Clamp the horizontal input to be between -1 and 1
		horizontal = Mathf.Clamp(horizontal, -1f, 1f);
	}

	private void FixedUpdate()
	{
		//In FixedUpdate() we set a flag that lets inputs to be cleared out during the 
		//next Update(). This ensures that all code gets to use the current inputs
		readyToClear = true;
	}

	private void ClearInput()
	{
		//If we're not ready to clear input, exit
		if (!readyToClear) return;

		//Reset all inputs
		horizontal = 0f;
		jumpPressed = false;
		jumpHeld = false;

		readyToClear = false;
	}

	private void ProcessInputs()
	{
		//Accumulate horizontal axis input
		//horizontal += Input.GetAxis("Horizontal");
		horizontal += Acceleration(isFalling);

		if (stopActing) return;

		//Accumulate button inputs
		jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
		jumpHeld = jumpHeld || Input.GetButton("Jump");
	}

	private float Acceleration(bool isFalling)
    {
		velocityPerSecond = isFalling && velocityPerSecond > 0 ? -velocityPerSecond : velocityPerSecond;
		timer += Time.deltaTime;
		if(timer >= interval)
        {
			inputValue = Mathf.Clamp(inputValue + velocityPerSecond * Time.deltaTime, -1, 1);
			timer = 0f;
		}

		inputValue = isFalling && inputValue > 0 ? -inputValue : inputValue;
		return inputValue;
	}

	private void PlayerFalling()
	{
		isFalling = true;
		stopActing = true;
	}

	public void ResetToDefault()
    {
		//Debug.Log("reset to default");
		horizontal = 0f;
		inputValue = _initialInputValue;
		velocityPerSecond = _initialVelocityPerSecond;
    }
}