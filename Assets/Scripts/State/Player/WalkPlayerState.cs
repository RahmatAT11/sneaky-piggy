using Controllers.Player;
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
            if (PlayerController.MovementDirectionEx.y > 0 && PlayerController.MovementDirectionEx.x == 0)
            {
                PlayerController.AnimationController.ChangeAnimationData(2);
            }
            else if (PlayerController.MovementDirectionEx.y < 0 && PlayerController.MovementDirectionEx.x == 0)
            {
                PlayerController.AnimationController.ChangeAnimationData(1);
            }
            else
            {
                PlayerController.AnimationController.ChangeAnimationData(0);
            }

            PlayerController.AnimationController.ArmatureComponent.animation.Play("Walk");
        }

        public override void OnStateExit()
        {
            PlayerController.AnimationController.ArmatureComponent.animation.Stop("Walk");
        }
        
        private bool IsMoving()
        {
            return PlayerController.GetMovementDirection() != Vector3.zero;
        }
    }
}