using DataStructures.Variables;
using Features.Input.Logic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Features.GameController.Logic
{
    public abstract class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] protected CursorData cursorData;
        
        [Header("If filled, this button does not work as long as a dialog is open")]
        [SerializeField] protected BoolVariable dialogueIsActive;
        
        [Header("Prevents Buttons from working when a transition is running")]
        [SerializeField] protected BoolVariable transitionIsRunning;
        
        [Header("Only for Glasses")]
        [SerializeField] protected BoolVariable canCollectGlasses;
        
        [Header("Object related")]
        [SerializeField] protected GameObject hoverEffect;

        private bool isHover;

        protected virtual void Awake()
        {
            hoverEffect.SetActive(false);
        }

        protected virtual void OnEnable()
        {
            hoverEffect.SetActive(false);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            if (canCollectGlasses != null) if (!canCollectGlasses.Get()) return;
            
            if (cursorData.Hover != null)
            {
                cursorData.ChangeToCursor(cursorData.Hover);
            }
            
            if (hoverEffect == null) return;
            hoverEffect.SetActive(true);
            
            isHover = true;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            if (canCollectGlasses != null) if (!canCollectGlasses.Get()) return;
            
            cursorData.ChangeToCursor(cursorData.Normal);
            
            if (hoverEffect == null) return;
            hoverEffect.SetActive(false);
            
            isHover = false;
        }
        
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            if (canCollectGlasses != null) if (!canCollectGlasses.Get()) return;
            
            cursorData.ChangeToCursor(cursorData.Clicked);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (transitionIsRunning != null) if (transitionIsRunning.Get()) return;
            if (dialogueIsActive != null) if (dialogueIsActive.Get()) return;
            
            if (canCollectGlasses != null) if (!canCollectGlasses.Get()) return;
            
            if (!isHover) return;
            
            cursorData.ChangeToCursor(cursorData.Hover);
        }
    }
}