using Controllers.NPC;

namespace State.NPC
{
    public class SearchNpcState : NpcState
    {
        public SearchNpcState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            // go to detected player position
            NonPlayerController.SetState(new HuntNpcState(NonPlayerController));
        }

        public override void OnStateEnter()
        {
            // start searching
        }

        public override void OnStateExit()
        {
            // stop searching
        }
    }
}