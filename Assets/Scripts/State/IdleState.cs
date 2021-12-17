using Controllers.Player;

namespace State
{
    public class IdleState : State
    {
        public IdleState(PlayerController playerController) : base(playerController)
        {
        }

        public override void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}