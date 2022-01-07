using Controllers.NPC;

namespace State.NPC
{
    public class IdleNpcState : NpcState
    {
        public IdleNpcState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            NonPlayerController.DetectPlayer();
            CheckIfPlayerDetected();
        }

        private void CheckIfPlayerDetected()
        {
            if (NonPlayerController.IsPlayerDetected)
            {
                NonPlayerController.SetState(new SearchNpcState(NonPlayerController));
            }
        }

        private void CheckIfPathsAvailable()
        {
            if (NonPlayerController.GetDefaultPathSize() > 1)
            {
                NonPlayerController.SetState(new FollowPathNpcState(NonPlayerController));
            }
        }

        public override void OnStateEnter()
        {
            NonPlayerController.IsStandingStill = true;
            NonPlayerController.LookDirection();
            CheckIfPathsAvailable();
            NonPlayerController.GetCurrentUac().animation.Play("Idle");
        }

        public override void OnStateExit()
        {
            NonPlayerController.IsStandingStill = false;
            NonPlayerController.GetCurrentUac().animation.Stop("Idle");
        }
    }
}