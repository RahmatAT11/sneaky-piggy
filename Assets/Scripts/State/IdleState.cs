using Controllers.Player;
using UnityEngine;

namespace State
{
    public class IdleState : State
    {
        public IdleState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            if (IsMoving())
            {
                if (PlayerController.IsSprintingEx)
                {
                    PlayerController.SetState(new RunState(PlayerController));
                }
                else
                {
                    PlayerController.SetState(new WalkState(PlayerController));
                }
            }
        }

        public override void OnStateEnter()
        {
            PlayerController.PlayerArmature.animation.Play("Idle");
        }

        public override void OnStateExit()
        {
            PlayerController.PlayerArmature.animation.Stop("Idle");
        }

        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}