// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// Edit: Gino Georgiev
// Date:   02/10/22
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

namespace DataStructures.Event
{
    public class GameEventListenerWithPara<T> : MonoBehaviour
    {
        [SerializeField] private GameEventWithPara_SO<T> @event;
        [SerializeField] private UnityEvent<T> response;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {
            @event.UnregisterListener(this);
        }

        public void OnEventRaised(T t)
        {
            response.Invoke(t);
        }
    }
}
