using System.Collections.Generic;
using DataStructures.Event;
using UnityEngine;

namespace Features.GameController.Logic
{
    [CreateAssetMenu(fileName = "newDoTransitionEvent", menuName = "Features/GameLogic/DoTransitionEvent", order = 2)]
    public class DoTransitionEvent : ActionEventWithParameter<List<GameEvent_SO>>
    {
        
    }
}