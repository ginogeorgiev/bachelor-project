using DataStructures.Event;
using UnityEngine;

namespace Features.Input.Logic
{
    [CreateAssetMenu(fileName = "newChangeCursorEvent", menuName = "Features/Input/ChangeCursorEvent")]
    public class ChangeCursorEvent : ActionEventWithParameter<Texture2D>
    {
    }
}
