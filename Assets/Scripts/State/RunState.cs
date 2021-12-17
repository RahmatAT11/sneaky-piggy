using Controllers.Player;
using UnityEngine;

namespace State
{
    public class RunState : State
    {
        public RunState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            if (IsMoving())
            {
                if (!PlayerController.IsSprintingEx)
                {
                    PlayerController.SetState(new WalkState(PlayerController));
                }
            }
            else
            {
                PlayerController.SetState(new IdleState(PlayerController));
            }
        }
        
        public override void OnStateEnter()
        {
            PlayerController.PlayerArmature.animation.Play("Run");
        }

        public override void OnStateExit()
        {
            PlayerController.PlayerArmature.animation.Stop("Run");
        }
        
        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}