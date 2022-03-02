using DataStructures.Event;
using UnityEngine;

namespace Features.GameController.Logic
{
    [CreateAssetMenu(fileName = "newTransitionData", menuName = "Features/GameLogic/TransitionData", order = 1)]
    public class TransitionData : ScriptableObject
    {
        [SerializeField] private DoTransitionEvent doTransitionEvent;
        [SerializeField] private float waitTimeBetweenFades;
        
        [SerializeField] private float fadeInTime;
        [SerializeField] private float fadeOutTime;
        [SerializeField] private LeanTweenType fadeInEaseType;
        [SerializeField] private LeanTweenType fadeOutEaseType;

        [SerializeField] private GameEvent_SO onStart;
        [SerializeField] private GameEvent_SO onEnd;

        [SerializeField] private GameEvent_SO onStartCompleted;
        [SerializeField] private GameEvent_SO onEndCompleted;

        public DoTransitionEvent DoTransitionEvent => doTransitionEvent;
        public float WaitTimeBetweenFades => waitTimeBetweenFades;
        public float FadeInTime => fadeInTime;
        public float FadeOutTime => fadeOutTime;
        public LeanTweenType FadeInEaseType => fadeInEaseType;
        public LeanTweenType FadeOutEaseType => fadeOutEaseType;
        public GameEvent_SO OnStart => onStart;
        public GameEvent_SO OnEnd => onEnd;
        public GameEvent_SO OnStartCompleted => onStartCompleted;
        public GameEvent_SO OnEndCompleted => onEndCompleted;
    }
}