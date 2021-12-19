using Controllers.NPC;

namespace State.NPC
{
    public abstract class NpcState
    {
        protected readonly NonPlayerController NonPlayerController;

        public abstract void Tick();

        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}

        protected NpcState(NonPlayerController nonPlayerController)
        {
            NonPlayerController = nonPlayerController;
        }
    }
}