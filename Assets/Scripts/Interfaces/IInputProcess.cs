using Controllers.Joystick;
using UnityEngine;

namespace Interfaces
{
    public interface IInputProcess
    {
        public Vector3 MovementInput(GameJoystickController joystickController);
    }
}