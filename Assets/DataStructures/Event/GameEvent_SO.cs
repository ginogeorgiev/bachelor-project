// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace DataStructures.Event
{
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "DataStructures/Event/GameEvent")]
    public class GameEvent_SO : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
            // Debug.Log("<color=#2A5BA7><b> " + name + " was raised.</b></color>");
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }
    }
}
