using Controllers.NPC;

namespace State.Direction
{
    public abstract class DirectionNonPlayerState
    {
        protected readonly NonPlayerController NonPlayerController;

        public abstract void Tick();

        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        protected DirectionNonPlayerState(NonPlayerController nonPlayerController)
        {
            NonPlayerController = nonPlayerController;
        }
    }
}