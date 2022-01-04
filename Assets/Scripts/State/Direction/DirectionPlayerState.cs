using Controllers.Player;

namespace State.Direction
{
    public abstract class DirectionPlayerState
    {
        protected readonly PlayerController PlayerController;

        public abstract void Tick();

        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        protected DirectionPlayerState(PlayerController playerController)
        {
            PlayerController = playerController;
        }
    }
}