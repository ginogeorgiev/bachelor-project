
namespace DataStructures.CommandLogic
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
