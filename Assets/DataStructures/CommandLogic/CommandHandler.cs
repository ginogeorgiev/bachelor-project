using System.Collections.Generic;

namespace DataStructures.CommandLogic
{
    public class CommandHandler
    {
        private readonly Stack<ICommand> commandStack = new Stack<ICommand>();
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();

        public void PushCommand(ICommand command)
        {
            commandStack.Push(command);
            undoStack.Clear();
            command.Execute();
        }

        public void UndoCommand(out bool undoSucceeded)
        {
            undoSucceeded = false;
            if (commandStack.Count == 0) return;
            
            ICommand command = commandStack.Pop();
            undoStack.Push(command);
            command.Undo();

            undoSucceeded = true;
        }

        public void RedoCommand(out bool redoSucceeded)
        {
            redoSucceeded = false;
            if (undoStack.Count == 0) return;
            
            ICommand command = undoStack.Pop();
            commandStack.Push(command);
            command.Execute();

            redoSucceeded = true;
        }
    }
}