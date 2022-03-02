using UnityEngine;

namespace Features.Input.Logic
{
    [CreateAssetMenu(fileName = "newCursorData", menuName = "Features/Input/CursorData")]
    public class CursorData : ScriptableObject
    {
        [Header("Cursor related")]
        [SerializeField] private ChangeCursorEvent changeCursorEvent;
        [SerializeField] private Texture2D normal;
        [SerializeField] private Texture2D hover;
        [SerializeField] private Texture2D clicked;

        public ChangeCursorEvent ChangeCursorEvent => changeCursorEvent;

        public Texture2D Normal => normal;
        public Texture2D Hover => hover;
        public Texture2D Clicked => clicked;

        public void ChangeToCursor(Texture2D cursor)
        {
            changeCursorEvent.Raise(cursor);
        }
    }
}