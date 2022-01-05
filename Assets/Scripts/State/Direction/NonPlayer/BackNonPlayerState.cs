using Controllers.NPC;

namespace State.Direction.NonPlayer
{
    public class BackNonPlayerState : DirectionNonPlayerState
    {
        public BackNonPlayerState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            ChangeAnimationDirection();
        }
        
        public override void OnStateEnter()
        {
            NonPlayerController.SetCurrentUac(1);
            
            NonPlayerController.GetCurrentUac().animation.Play(
                NonPlayerController.GetCurrentUac().animation.lastAnimationName);
        }
        
        public override void OnStateExit()
        {
            NonPlayerController.GetListOfAnimationControllers()[1].SetActiveAnimation(false);
        }
        
        private void ChangeAnimationDirection()
        {
            if (NonPlayerController.GetMovementDirection().y <= 0.1f)
            {
                NonPlayerController.SetState(new SideNonPlayerState(NonPlayerController));
            }
        }
    }
}