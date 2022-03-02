using DataStructures.CommandLogic;
using Features.CommandLevel.Logic;
using UnityEngine;

namespace Features.CommandLevel.UILogic
{
    public class CommandInputController : MonoBehaviour
    {
        [SerializeField] private CommandCharacterController commandCharacter;
        [SerializeField] private UICommandViewController uiCommandViewController;

        [SerializeField] private CommandData commandData;

        private void SendMoveCommand(Transform objectToMove, Vector3 direction, float distance, GameObject textPrefab)
        {
            ICommand movement = new MoveCommand(objectToMove, direction, distance);
            commandCharacter.OnPushCommand(movement as MoveCommand);
            uiCommandViewController.PushCommandItem(textPrefab);
        }
        
        public void OnUndoCommand()
        {
            commandCharacter.OnUndoCommand();
            uiCommandViewController.PushUndoItem();
        }
        
        public void OnRedoCommand()
        {
            commandCharacter.OnRedoCommand();
            uiCommandViewController.PushRedoItem();
        }
        
        public void OnMoveUpCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.y + 1 > 7) return;
            
            SendMoveCommand(commandCharacter.transform, Vector3.up, 1f, commandData.UpTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveDownCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.y - 1 < 0) return;
            
            SendMoveCommand(commandCharacter.transform, Vector3.down, 1f, commandData.DownTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveLeftCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x - 1 < 0) return;
            
            SendMoveCommand(commandCharacter.transform, Vector3.left, 1f, commandData.LeftTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveRightCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x + 1 > 7) return;
            
            SendMoveCommand(commandCharacter.transform, Vector3.right, 1f, commandData.RightTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveUpRightCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x + 1 > 7 || position.y + 1 > 7) return;
            
            SendMoveCommand(commandCharacter.transform, new Vector3(1,1,0), 1f, commandData.UpRightTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveUpLeftCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x - 1 < 0 || position.y + 1 > 7) return;
            
            SendMoveCommand(commandCharacter.transform, new Vector3(-1,1,0), 1f, commandData.UpLeftTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveDownRightCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x + 1 > 7 || position.y - 1 < 0) return;
            
            SendMoveCommand(commandCharacter.transform, new Vector3(1,-1,0), 1f, commandData.DownRightTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
        
        public void OnMoveDownLeftCommand()
        {
            Vector3 position = commandCharacter.transform.position;
            if (position.x - 1 < 0 || position.y - 1 < 0) return;
            
            SendMoveCommand(commandCharacter.transform, new Vector3(-1,-1,0), 1f, commandData.DownLeftTextPrefab);
            uiCommandViewController.ClearUndoStack();
        }
    }
}
