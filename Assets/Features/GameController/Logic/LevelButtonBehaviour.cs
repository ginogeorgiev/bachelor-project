using System.Collections.Generic;
using DataStructures.Event;
using DataStructures.Variables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.GameController.Logic
{
    public class LevelButtonBehaviour : ButtonBehaviour
    {
        [SerializeField] private DoTransitionEvent doTransitionEvent;
        
        [SerializeField] private BoolVariable isIdleState;
        
        [Header("Level dependent")]
        [SerializeField] private GameEvent_SO activateEvent;
        [SerializeField] private GameEvent_SO deActivateEvent;
        [SerializeField] private BoolVariable stopRunning;
        [SerializeField] private BoolVariable startRunning;

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            
            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            // special case for State Level so that StateHandler Coroutines will not stop,
            // back to main Menu can only be clicked when in idleState
            if (isIdleState != null) if (!isIdleState.Get()) return;

            // prepares and sends Events which will be raised in between the transition
            List<GameEvent_SO> eventList = new List<GameEvent_SO>
            {
                deActivateEvent,
                activateEvent
            };

            doTransitionEvent.Raise(eventList);
            stopRunning.SetFalse();
            startRunning.SetTrue();
        }
    }
}
