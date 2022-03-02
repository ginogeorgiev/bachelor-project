using DataStructures.Event;
using UnityEngine;

namespace Features.Dialogue.Logic
{
    [CreateAssetMenu(fileName = "newDialogueQuestionEvent", menuName = "Features/Dialog/DialogueQuestionEvent")]
    public class DialogueQuestionEvent : ActionEventWithParameter<DialogueElement>
    {
        
    }
}
