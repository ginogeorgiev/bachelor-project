using UnityEngine;

namespace Features.CommandLevel.Logic
{
    public class PathDrawer : MonoBehaviour
    {
        [SerializeField] private LineRenderer line;

        private const float VerticalOffset = -1f;
        private Vector3 startPoint;

        public void SetStartPosition(Transform transform)
        {
            startPoint = transform.position;
            startPoint.z = VerticalOffset;
            line.SetPosition(line.positionCount - 1, startPoint);
        }

        public void OnPushCommand(Transform transform)
        {
            line.positionCount += 1;
            Vector3 newPosition = transform.position;
            newPosition.z = VerticalOffset;
            line.SetPosition(line.positionCount - 1, newPosition);
        }

        public void OnUndoCommand()
        {
            line.positionCount -= 1;
        }

        public void OnRedoCommand(Transform transform)
        {
            line.positionCount += 1;
            Vector3 newPosition = transform.position;
            newPosition.z = VerticalOffset;
            line.SetPosition(line.positionCount - 1, newPosition);
        }
    }
}
