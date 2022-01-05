using Controllers.NPC;

namespace State.Direction
{
    public class FrontNonPlayerState : DirectionNonPlayerState
    {
        public FrontNonPlayerState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}