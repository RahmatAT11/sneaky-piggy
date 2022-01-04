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

            if (PlayerController.GetMovementDirection() == Vector3.zero)
            {
                PlayerController.GetCurrentUac().animation.Play("Idle");
            }
            else
            {
                PlayerController.GetCurrentUac().animation.Play(
                    PlayerController.GetCurrentUac().animation.lastAnimationName);
            }
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