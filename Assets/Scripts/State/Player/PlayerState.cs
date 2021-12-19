using Controllers.Player;

namespace State.Player
{
    public abstract class PlayerState
    {
        protected readonly PlayerController PlayerController;

        public abstract void Tick();

        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        protected PlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
        }
    }
}