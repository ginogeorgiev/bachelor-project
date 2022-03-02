// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// Edit: Gino Georgiev
// Date:   02/10/22
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace DataStructures.Event
{
    [CreateAssetMenu(fileName = "NewGameEventWithPara", menuName = "DataStructures/Event/GameEventWithPara")]
    public class GameEventWithPara_SO<T> : ScriptableObject
    {
        private List<GameEventListenerWithPara<T>> listeners = new List<GameEventListenerWithPara<T>>();

        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        public void Raise(T t)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(t);
            }
            // Debug.Log("<color=#2A5BA7><b> " + name + " was raised.</b></color>");
        }

        public void RegisterListener(GameEventListenerWithPara<T> listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListenerWithPara<T> listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
