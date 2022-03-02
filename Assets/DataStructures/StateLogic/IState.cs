
namespace DataStructures.StateLogic
{
    public interface IState
    {
        // one-time call, when entering a state
        void Enter();

        // this will be called frequently through an update method
        void Execute();

        // one-time call, when exiting a state
        void Exit();
    }
}