using Controllers.Player;
using UnityEngine;

namespace State
{
    public class WalkState : State
    {
        public WalkState(PlayerController playerController) : base(playerController)
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
            }
            else
            {
                PlayerController.SetState(new IdleState(PlayerController));
            }
        }

        public override void OnStateEnter()
        {
            PlayerController.PlayerArmature.animation.Play("Walk");
        }

        public override void OnStateExit()
        {
            PlayerController.PlayerArmature.animation.Stop("Walk");
        }
        
        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}