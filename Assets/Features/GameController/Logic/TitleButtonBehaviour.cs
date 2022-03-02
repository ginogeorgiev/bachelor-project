using System.Collections;
using DataStructures.Event;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.GameController.Logic
{
    public class TitleButtonBehaviour : ButtonBehaviour
    {
        [SerializeField] private GameEvent_SO onClickEvent;
        [SerializeField] private GameObject titleButtons;
        [SerializeField] private float slideTime;

        private bool coroutineIsRunning;
        private Vector3 titleButtonsStartPosition;
        private Vector3 titleButtonsTargetPosition;

        private void Start()
        {
            titleButtons.SetActive(false);
            
            titleButtonsStartPosition = titleButtons.transform.localPosition;
            titleButtonsTargetPosition = Vector3.zero;

            ToggleTitleButtons();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            
            onClickEvent.Raise();
        }

        public void ToggleTitleButtons()
        {
            if (coroutineIsRunning) return;

            StartCoroutine(titleButtons.activeSelf ? SlideIn(titleButtons) : SlideOut(titleButtons));
        }

        private IEnumerator SlideIn(GameObject objectToSlide)
        {
            coroutineIsRunning = true;

            LeanTween.moveLocal(objectToSlide, titleButtonsStartPosition, slideTime)
                .setEase(LeanTweenType.easeInOutQuint);

            yield return new WaitForSeconds(slideTime);
            
            objectToSlide.SetActive(false);
            coroutineIsRunning = false;
        }

        private IEnumerator SlideOut(GameObject objectToSlide)
        {
            coroutineIsRunning = true;
            objectToSlide.SetActive(true);
            
            LeanTween.moveLocal(objectToSlide, titleButtonsTargetPosition, slideTime)
                .setEase(LeanTweenType.easeOutElastic);

            yield return new WaitForSeconds(slideTime);
            
            coroutineIsRunning = false;
        }
    }
}
