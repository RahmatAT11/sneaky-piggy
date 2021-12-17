using Controllers.Player;

namespace State
{
    public abstract class State
    {
        protected PlayerController PlayerController;

        public abstract void Tick();

        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        public State(PlayerController playerController)
        {
            PlayerController = playerController;
        }
    }
}