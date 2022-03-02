using DataStructures.Event;
using UnityEngine;

namespace DataStructures.StateLogic
{
    [CreateAssetMenu(fileName = "newOnStateEnterEvent", menuName = "DataStructures/StateLogic/OnStateEnterEvent")]
    public class OnStateEnterEvent : ActionEventWithParameter<BaseState>
    {
    }
}
