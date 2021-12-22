using Controllers.NPC;
using UnityEngine;

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
            CheckIfPathsAvailable();
            // Play animation idle
        }

        public override void OnStateExit()
        {
            // stop animation idle
        }
    }
}