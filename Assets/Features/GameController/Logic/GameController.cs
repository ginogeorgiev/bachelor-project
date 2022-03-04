using System.Collections;
using System.Collections.Generic;
using DataStructures.Event;
using DataStructures.Variables;
using Features.Input.Logic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Features.GameController.Logic
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private TransitionData transitionData;
        [SerializeField] private CursorData cursorData;
        
        [SerializeField] private StringVariable messageText;
        
        [SerializeField] private BoolVariable transitionIsRunning;
        
        private void Start()
        {
            transitionData.DoTransitionEvent.RegisterListener(DoTransition);
        }

        private void DoTransition(List<GameEvent_SO> eventList)
        {
            if (transitionIsRunning.Get()) return;
            
            StartCoroutine(StartLevel(eventList));
        }

        private IEnumerator StartLevel(List<GameEvent_SO> eventList)
        {
            transitionIsRunning.SetTrue();
            
            transitionData.OnStart.Raise();
            yield return new WaitForSeconds(transitionData.FadeInTime);

            foreach (GameEvent_SO gameEvent in eventList)
            {
                gameEvent.Raise();
            }
            yield return new WaitForSeconds(transitionData.WaitTimeBetweenFades);
            transitionIsRunning.SetFalse();
            
            cursorData.ChangeToCursor(cursorData.Normal);
            transitionData.OnEnd.Raise();
            yield return new WaitForSeconds(transitionData.FadeOutTime);
        }

        public void OnChangeLanguageToEng()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            
            messageText.Set("Please insert money.");
        }

        public void OnChangeLanguageToGer()
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            
            messageText.Set("Bitte geben Sie Geld ein.");
        }

        public void OnQuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
            
        }
    }
}
