using Controllers.NPC;

namespace State.NPC
{
    public class HuntNpcState : NpcState
    {
        public HuntNpcState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            NonPlayerController.MoveNpcToPlayer();
            if (!NonPlayerController.IsPlayerDetected)
            {
                NonPlayerController.SetState(new FollowPathNpcState(NonPlayerController));
            }
            // if stamina < 0 than take a break
        }
        
        public override void OnStateEnter()
        {
            NonPlayerController.IsSprintingEx = true;
            // play animation sprint
            // take away stamina
        }

        public override void OnStateExit()
        {
            
            // Stop animation sprint
        }
    }
}