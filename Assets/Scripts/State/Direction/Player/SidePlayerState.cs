using Controllers.Player;
using UnityEngine;

namespace State.Direction.Player
{
    public class SidePlayerState : DirectionPlayerState
    {
        public SidePlayerState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            ChangeAnimationDirection();
        }
        
        public override void OnStateEnter()
        {
            PlayerController.SetCurrentUac(0);

            PlayerController.GetCurrentUac().animation.Play(PlayerController.GetMovementDirection() == Vector3.zero
                ? "Idle"
                : PlayerController.GetCurrentUac().animation.lastAnimationName);
        }

        public override void OnStateExit()
        {
            PlayerController.GetListOfAnimationControllers()[0].SetActiveAnimation(false);
        }
        
        private void ChangeAnimationDirection()
        {
            if (PlayerController.GetMovementDirection().y > 0.5f)
            {
                PlayerController.SetState(new BackPlayerState(PlayerController));
            }
            
            if (PlayerController.GetMovementDirection().y < -0.5f)
            {
                PlayerController.SetState(new FrontPlayerState(PlayerController));
            }
        }
    }
}