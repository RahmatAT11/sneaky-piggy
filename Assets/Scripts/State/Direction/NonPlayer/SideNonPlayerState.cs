using Controllers.NPC;

namespace State.Direction
{
    public class SideNonPlayerState : DirectionNonPlayerState
    {
        public SideNonPlayerState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}