using System.Collections.Generic;
using DataStructures.Variables;
using UnityEngine;

namespace Features.Dialogue.Logic
{
    [CreateAssetMenu(fileName = "newDialogueElement", menuName = "Features/Dialog/DialogueElement")]
    public class DialogueElement : ScriptableObject
    {
        // bool that need to be true to send NextElement
        [SerializeField] private List<BoolVariable> forSendNextElement;
        
        [SerializeField] private List<GameObject> dialogueTexts;
        [SerializeField] private DialogueElement nextElement;
        
        // SetTrue when completed
        [SerializeField] private List<BoolVariable> onCompletion;
        
        [Header("For Debug")]
        [SerializeField] private bool isInstantly;

        public List<GameObject> DialogueTexts => dialogueTexts;
        public bool IsInstantly => isInstantly;

        public DialogueElement CheckForNextElement(out bool allCompleted)
        {
            allCompleted = false;
            if (forSendNextElement == null || forSendNextElement.Count == 0) return this;
            allCompleted = true;
            foreach (BoolVariable boolVariable in forSendNextElement)
            {
                if (!boolVariable.Get())
                {
                    allCompleted = false;
                }
            }

            return allCompleted ? nextElement : this;
        }

        public void Completed()
        {
            foreach (BoolVariable boolVariable in onCompletion)
            {
                boolVariable.SetTrue();
            } 
        }
    }
}
