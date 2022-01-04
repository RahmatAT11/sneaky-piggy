using Controllers.Player;

namespace State.Direction.Player
{
    public class FrontPlayerState : DirectionPlayerState
    {
        public FrontPlayerState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            ChangeAnimationDirection();
        }

        public override void OnStateEnter()
        {
            PlayerController.SetCurrentUac(1);

            PlayerController.GetCurrentUac().animation.Play(
                PlayerController.GetCurrentUac().animation.lastAnimationName);
        }
        
        public override void OnStateExit()
        {
            PlayerController.GetListOfAnimationControllers()[1].SetActiveAnimation(false);
        }
        
        private void ChangeAnimationDirection()
        {
            if (PlayerController.GetMovementDirection().y > 0.5f)
            {
                PlayerController.SetState(new BackPlayerState(PlayerController));
            }

            if (PlayerController.GetMovementDirection().y <= 0.4f
            && PlayerController.GetMovementDirection().y > -0.5f)
            {
                PlayerController.SetState(new SidePlayerState(PlayerController));
            }
        }
    }
}