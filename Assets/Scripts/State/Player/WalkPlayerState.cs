using Controllers.Player;
using State.Direction.Player;
using UnityEngine;

namespace State.Player
{
    public class WalkPlayerState : PlayerState
    {
        public WalkPlayerState(PlayerController playerController) : base(playerController)
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
            PlayerController.GetCurrentUac().animation.Play("Walk");
        }

        public override void OnStateExit()
        {
            PlayerController.GetCurrentUac().animation.Stop("Walk");
        }
        
        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}