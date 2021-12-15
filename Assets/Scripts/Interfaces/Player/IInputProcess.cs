using Controllers.Joystick;
using UnityEngine;

namespace Interfaces.Player
{
    public interface IInputProcess
    {
        public Vector3 MovementInput(GameJoystickController joystickController);
    }
}