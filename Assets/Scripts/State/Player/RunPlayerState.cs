using Controllers.Player;
using UnityEngine;

namespace State.Player
{
    public class RunPlayerState : PlayerState
    {
        public RunPlayerState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            if (IsMoving())
            {
                if (!PlayerController.IsSprintingEx)
                {
                    PlayerController.SetState(new WalkPlayerState(PlayerController));
                }
            }
            else
            {
                PlayerController.SetState(new IdlePlayerState(PlayerController));
            }
        }
        
        public override void OnStateEnter()
        {
            if (PlayerController.GetMovementDirection().y > 0 && PlayerController.GetMovementDirection().x == 0)
            {
                PlayerController.SetCurrentUac(2);
            }
            else if (PlayerController.GetMovementDirection().y < 0 && PlayerController.GetMovementDirection().x == 0)
            {
                PlayerController.SetCurrentUac(1);
                
            }
            else
            {
                PlayerController.SetCurrentUac(0);
                
            }

            PlayerController.GetCurrentUac().animation.Play("Run");
        }

        public override void OnStateExit()
        {
            PlayerController.GetCurrentUac().animation.Stop("Run");
        }
        
        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}