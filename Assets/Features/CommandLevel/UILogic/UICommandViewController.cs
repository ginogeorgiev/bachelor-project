using System;
using DataStructures.Variables;
using UnityEngine;

namespace Features.CommandLevel.UILogic
{
    public class UICommandViewController : MonoBehaviour
    {
        [SerializeField] private Transform commandStackContent;
        [SerializeField] private Transform undoStackContent;
        
        [SerializeField] private GameObject commandStack;
        [SerializeField] private GameObject undoStack;
        
        [SerializeField] private BoolVariable glassesAreCollected;

        private void Awake()
        {
            commandStack.SetActive(false);
            undoStack.SetActive(false);
        }

        private void OnEnable()
        {
            if (!glassesAreCollected.Get()) return;
            
            commandStack.SetActive(true);
            undoStack.SetActive(true);
        }

        public void PushCommandItem(GameObject textPrefab)
        {
            Instantiate(textPrefab, commandStackContent);
        }

        public void PushUndoItem()
        {
            if (commandStackContent.childCount == 0) return;
            
            commandStackContent.GetChild(commandStackContent.childCount - 1).transform.SetParent(undoStackContent);
        }

        public void PushRedoItem()
        {
            if (undoStackContent.childCount == 0) return;
            
            undoStackContent.GetChild(undoStackContent.childCount - 1).transform.SetParent(commandStackContent);
        }

        public void ClearUndoStack()
        {
            if (undoStackContent.childCount == 0) return;
            
            foreach (Transform child in undoStackContent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
