using Controllers.Player;

namespace State
{
    public class WalkState : State
    {
        public WalkState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}