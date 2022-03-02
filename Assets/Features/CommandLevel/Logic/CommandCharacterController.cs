using DataStructures.CommandLogic;
using UnityEngine;

namespace Features.CommandLevel.Logic
{
    public class CommandCharacterController : MonoBehaviour
    {
        [SerializeField] private PathDrawer pathDrawer;
        private CommandHandler commandHandler;

        private void Start()
        {
            commandHandler = new CommandHandler();
            pathDrawer.SetStartPosition(transform);
        }

        public void OnPushCommand(MoveCommand command)
        {
            commandHandler.PushCommand(command);
            pathDrawer.OnPushCommand(transform);
        }

        public void OnUndoCommand()
        {
            commandHandler.UndoCommand(out bool undoSucceeded);
            if (undoSucceeded) pathDrawer.OnUndoCommand();
        }

        public void OnRedoCommand()
        {
            commandHandler.RedoCommand(out bool redoSucceeded);

            if (redoSucceeded) pathDrawer.OnRedoCommand(transform);
        }
    }
}