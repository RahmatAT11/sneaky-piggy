using Controllers.NPC;

namespace State.Direction
{
    public class BackNonPlayerState : DirectionNonPlayerState
    {
        public BackNonPlayerState(NonPlayerController nonPlayerController) : base(nonPlayerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}