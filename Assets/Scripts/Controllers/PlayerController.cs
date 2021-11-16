using UnityEngine;

public class PlayerController : BaseCharController
{
    private GameJoystickController _joystick;
    
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _joystick = FindObjectOfType<GameJoystickController>();
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        /*float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");*/

        float xAxis = _joystick.InputHorizontal();
        float yAxis = _joystick.InputVertical();

        MovementDirection.Set(xAxis, yAxis, 0f);
    }

    private void FixedUpdate()
    {
        Walking();
        Turning();
        Sprinting();
    }
}
