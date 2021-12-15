using Controllers.Joystick;
using Interfaces.Player;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerInput : MonoBehaviour, IInputProcess
    {
        public Vector3 MovementInput(GameJoystickController joystickController)
        {
            float xAxis = joystickController.InputHorizontal();
            float yAxis = joystickController.InputVertical();

            return new Vector3(xAxis, yAxis, 0f);
        }
    }
}