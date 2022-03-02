using System;
using DataStructures.Variables;
using TMPro;
using UnityEngine;

namespace Features.StateLevel.UILogic
{
    public class UIStateFeedbackController : MonoBehaviour
    {
        [SerializeField] private StringVariable currentMessage;
        [SerializeField] private TMP_Text feedbackMessageText;
        
        [SerializeField] private IntVariable playerMoneyAmount;
        [SerializeField] private TMP_Text moneyAmountText;
        
        //Temporary til Dialog is implemented
        private void Awake()
        {
            UpdateMoneyAmount();
        }

        public void UpdateMessage()
        {
            feedbackMessageText.text = currentMessage.Get();
        }
        
        public void UpdateMoneyAmount()
        {
            moneyAmountText.text = playerMoneyAmount.Get() + " / 100";
        }
    }
}