using Controllers.NPC;

namespace State.NPC
{
    public class FollowPathNpcState : NpcState
    {
        public FollowPathNpcState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            NonPlayerController.MoveNpcToPath();
            NonPlayerController.DetectPlayer();
            CheckIfPlayerDetected();
            CheckIfPathOnlyOne();
        }

        private void CheckIfPlayerDetected()
        {
            if (NonPlayerController.IsPlayerDetected)
            {
                NonPlayerController.SetState(new SearchNpcState(NonPlayerController));
            }
        }

        public override void OnStateEnter()
        {
            NonPlayerController.IsSprintingEx = false;
            // play animation walk
        }

        private void CheckIfPathOnlyOne()
        {
            if (NonPlayerController.GetDefaultPathSize() <= 1)
            {
                NonPlayerController.SetState(new IdleNpcState(NonPlayerController));
            }
        }

        public override void OnStateExit()
        {
            // stop animation walk
        }
    }
}