using Controllers.Player;
using UnityEngine;

namespace State.Player
{
    public class IdlePlayerState : PlayerState
    {
        public IdlePlayerState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            if (IsMoving())
            {
                if (PlayerController.IsSprintingEx)
                {
                    PlayerController.SetState(new RunPlayerState(PlayerController));
                }
                else
                {
                    PlayerController.SetState(new WalkPlayerState(PlayerController));
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