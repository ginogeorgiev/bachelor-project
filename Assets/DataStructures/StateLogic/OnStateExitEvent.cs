using DataStructures.Event;
using UnityEngine;

namespace DataStructures.StateLogic
{
    [CreateAssetMenu(fileName = "newOnStateExitEvent", menuName = "DataStructures/StateLogic/OnStateExitEvent")]
    public class OnStateExitEvent : ActionEventWithParameter<BaseState>
    {
        
    }
}
