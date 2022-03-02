using DataStructures.Event;
using DataStructures.Variables;
using Features.Dialogue.Logic;
using UnityEngine;

namespace Features.Dialogue.UILogic
{
    public class DialogueController : MonoBehaviour
    {
        [Header("SOs")]
        [SerializeField] private GameEvent_SO onTriggerTalkingAnim;
        [SerializeField] private BoolVariable dialogueIsActive;
        [SerializeField] private IntVariable currentDialogueIndex;
        [SerializeField] private DialogueQuestionEvent dialogueQuestionEvent;
        
        [Header("Inner prefab objects")]
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private GameObject continueButton;

        [Header("Sequences")]
        [SerializeField] private DialogueElement currentMainElement;
        [SerializeField] private DialogueElement currentStateElement;
        [SerializeField] private DialogueElement currentCommandElement;

        [Header("For Debug")]
        [SerializeField] private DialogueElement currentDialogueElement;

        [SerializeField] private GameObject currentDialogueBoxContent;

        [SerializeField] private bool dialogueStarted;

        private void Awake()
        {
            dialogueBox.SetActive(false);
            dialogueIsActive.SetFalse();
            currentDialogueIndex.Restore();
            
            dialogueQuestionEvent.RegisterListener(SetCurrentDialogueElement);

            OnDrPatternClicked();
        }

        private void SetCurrentDialogueElement(DialogueElement dialogueElement)
        {
            currentDialogueElement = dialogueElement;

            if (currentDialogueElement.IsInstantly)
            {
                InitializeDialogue();
            }
        }

        public void OnDrPatternClicked()
        {
            if (dialogueStarted) return;
            
            InitializeDialogue();
        }

        public void OnContinueButtonClicked()
        {
            ReplaceTextElement();
        }

        private void InitializeDialogue()
        {
            if (currentDialogueElement == null) return;

            dialogueStarted = true;
            dialogueBox.SetActive(true);
            continueButton.SetActive(true);
            onTriggerTalkingAnim.Raise();
            dialogueIsActive.SetTrue();

            CheckForNextDialog();
            
            currentDialogueIndex.Restore();
            if (currentDialogueElement != null) Destroy(currentDialogueBoxContent);
            currentDialogueBoxContent = Instantiate(currentDialogueElement.DialogueTexts[currentDialogueIndex.Get()], transform);
        }

        private void CheckForNextDialog()
        {
            while (true)
            {
                DialogueElement nextElement = currentDialogueElement.CheckForNextElement(out bool allCompleted);
                if (allCompleted)
                {
                    currentDialogueElement = nextElement;
                    continue;
                }

                currentDialogueElement = nextElement;
                break;
            }
        }

        private void ReplaceTextElement()
        {
            if (currentDialogueElement == null || currentDialogueElement.DialogueTexts.Count == 0) return;
            
            if (currentDialogueIndex.Get() == currentDialogueElement.DialogueTexts.Count - 1)
            {
                currentDialogueElement.Completed();
                CloseDialogue();
                CheckForNextDialog();
                return;
            }

            if (currentDialogueElement.DialogueTexts[currentDialogueIndex.Get() + 1].name.Contains("Question"))
            { 
                onTriggerTalkingAnim.Raise();
                Destroy(currentDialogueBoxContent);
                continueButton.SetActive(false);
                currentDialogueBoxContent = Instantiate(currentDialogueElement.DialogueTexts[currentDialogueIndex.Get() + 1], transform);
                currentDialogueIndex.Restore();
            }
            else
            {
                onTriggerTalkingAnim.Raise();
                Destroy(currentDialogueBoxContent);
                continueButton.SetActive(true);
                currentDialogueBoxContent = Instantiate(currentDialogueElement.DialogueTexts[currentDialogueIndex.Get() + 1], transform);
                currentDialogueIndex.Add(1);
            }
        }

        private void CloseDialogue()
        {
            currentDialogueIndex.Restore();
            dialogueBox.SetActive(false);
            dialogueIsActive.SetFalse();
            Destroy(currentDialogueBoxContent);
            dialogueStarted = false;
        }

        public void SwitchCurrentMainMenuDialogueElement()
        {
            if (currentDialogueElement.name.Contains("State"))
            {
                currentStateElement = currentDialogueElement;
            }
            else if (currentDialogueElement.name.Contains("Command"))
            {
                currentCommandElement = currentDialogueElement;
            }
            
            currentDialogueElement = currentMainElement;
        }

        public void SwitchCurrentStateLevelDialogueElement()
        {
            currentMainElement = currentDialogueElement;
            currentDialogueElement = currentStateElement;
        }

        public void SwitchCurrentCommandLevelDialogueElement()
        {
            currentMainElement = currentDialogueElement;
            currentDialogueElement = currentCommandElement;
        }
    }
}
