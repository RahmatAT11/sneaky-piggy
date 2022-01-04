using Controllers.Player;
using State.Direction.Player;
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
            ChangeAnimationDirection();
        }

        private void ChangeAnimationDirection()
        {
            if (PlayerController.GetMovementDirection().y > 0.5f)
            {
                PlayerController.SetState(new BackPlayerState(PlayerController));
            }
            else if (PlayerController.GetMovementDirection().y < -0.5f)
            {
                PlayerController.SetState(new FrontPlayerState(PlayerController));
            }
            else
            {
                PlayerController.SetState(new SidePlayerState(PlayerController));
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