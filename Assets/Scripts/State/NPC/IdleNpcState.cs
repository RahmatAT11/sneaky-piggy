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
            
        }

        public override void OnStateEnter()
        {
            // Play animation idle
        }

        public override void OnStateExit()
        {
            // stop animation idle
        }
    }
}