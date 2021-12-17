using Controllers.Player;

namespace State
{
    public class RunState : State
    {
        public RunState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}