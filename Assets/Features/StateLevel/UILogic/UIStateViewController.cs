using DataStructures.StateLogic;
using DataStructures.Variables;
using UnityEngine;

namespace Features.StateLevel.UILogic
{
    public class UIStateViewController : MonoBehaviour
    {
        [SerializeField] private OnStateEnterEvent onEnterEventEvent;
        [SerializeField] private OnStateExitEvent onExitEventEvent;
        
        [SerializeField] private Transform stateStackContent;
        
        [SerializeField] private GameObject stateStack;
        [SerializeField] private GameObject stateStackImage;
        
        [SerializeField] private BoolVariable glassesAreCollected;

        private void OnEnable()
        {
            if (!glassesAreCollected.Get()) return;
            
            stateStack.SetActive(true);
            stateStackImage.SetActive(true);
        }

        private void Awake()
        {
            stateStack.SetActive(false);
            stateStackImage.SetActive(false);
            onEnterEventEvent.RegisterListener(OnStateEnter);
            onExitEventEvent.RegisterListener(OnStateExit);
        }

        private void OnDisable()
        {
            if (stateStackContent == null || stateStackContent.childCount == 0) return;
            
            foreach (Transform child in stateStackContent)
            {
                Destroy(child.gameObject);
            }
        }

        private void AddStateItem(GameObject textPrefab)
        {
            Instantiate(textPrefab, stateStackContent);
        }

        private void OnStateEnter(BaseState state)
        {
            AddStateItem(state.Data.EnterStateText);
        }

        private void OnStateExit(BaseState state)
        {
            AddStateItem(state.Data.ExitStateText);
        }
    }
}