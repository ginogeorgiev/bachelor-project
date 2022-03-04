using DataStructures.Event;
using DataStructures.Variables;
using Features.Dialogue.Logic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.GameController.Logic
{
    public class ButtonWithOnClickEventBehaviour : ButtonBehaviour
    {
        [SerializeField] private GameEvent_SO onClickEvent;

        [Header("Dialogue related only use for dialogue buttons")]
        [SerializeField] private DialogueQuestionEvent dialogueQuestionEvent;
        [SerializeField] private DialogueElement dialogueElement;

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            if (canCollectGlasses != null) if (!canCollectGlasses.Get()) return;

            onClickEvent.Raise();
            
            if (dialogueElement != null && dialogueQuestionEvent != null) dialogueQuestionEvent.Raise(dialogueElement);
        }

        public void DestroyOnClick()
        {
            Destroy(gameObject);
        }
    }
}
