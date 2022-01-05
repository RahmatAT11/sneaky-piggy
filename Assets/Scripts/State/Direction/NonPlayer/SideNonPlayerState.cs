using Controllers.NPC;
using UnityEngine;

namespace State.Direction.NonPlayer
{
    public class SideNonPlayerState : DirectionNonPlayerState
    {
        public SideNonPlayerState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            ChangeAnimationDirection();
        }
        
        public override void OnStateEnter()
        {
            NonPlayerController.SetCurrentUac(0);

            if (NonPlayerController.GetMovementDirection() == Vector3.zero)
            {
                NonPlayerController.GetCurrentUac().animation.Play("Idle");
                return;
            }
            
            NonPlayerController.GetCurrentUac().animation.Play("Walk");
        }

        public override void OnStateExit()
        {
            NonPlayerController.GetListOfAnimationControllers()[0].SetActiveAnimation(false);
        }
        
        private void ChangeAnimationDirection()
        {
            if (NonPlayerController.GetMovementDirection().y > 0.1f)
            {
                NonPlayerController.SetState(new BackNonPlayerState(NonPlayerController));
            }
        }
    }
}