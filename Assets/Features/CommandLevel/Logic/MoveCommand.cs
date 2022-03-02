using DataStructures.CommandLogic;
using UnityEngine;

namespace Features.CommandLevel.Logic
{
    [System.Serializable]
    public class MoveCommand : ICommand
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float distance;
        [SerializeField] private Transform objectToMove;

        public MoveCommand(Transform objectToMove, Vector3 direction, float distance = 1f)
        {
            this.direction = direction;
            this.distance = distance;
            this.objectToMove = objectToMove;
        }

        public void Execute()
        {
            objectToMove.position += direction * distance;
        }

        public void Undo()
        {
            objectToMove.position -= direction * distance;
        }
    }
}
