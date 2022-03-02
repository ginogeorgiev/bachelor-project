using System.Collections;
using DataStructures.StateLogic;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace Features.StateLevel.Logic
{
    public class VendingMachineStateHandler : MonoBehaviour
    {
        [SerializeField] private StateData idleData;
        [SerializeField] private StateData moneyInputData;
        [SerializeField] private StateData numberInputData;
        [SerializeField] private StateData dispenseData;
        
        //For Buttons
        [SerializeField] private GameObject moneyInputSpot;
        [SerializeField] private GameObject numberInputField;
        [SerializeField] private GameObject moneyChangeSpot;
        [SerializeField] private GameObject itemDispenseSpot;

        private StateMachine stateMachine;
        
        private BaseState vendingMachineIdleState;
        private BaseState vendingMachineMoneyInputState;
        private BaseState vendingMachineNumberInputState;
        private BaseState vendingMachineDispenseState;
        
        [Header("Only for Debug")]
        [SerializeField] private string currentState;
        
        private void Awake()
        {
            stateMachine = new StateMachine();
            
            vendingMachineIdleState = new VendingMachineIdleState(idleData);
            vendingMachineMoneyInputState = new VendingMachineMoneyInputState(moneyInputData);
            vendingMachineNumberInputState = new VendingMachineNumberInputState(numberInputData);
            vendingMachineDispenseState = new VendingMachineDispenseState(dispenseData);
            
            stateMachine.Initialize(vendingMachineIdleState);
            currentState = stateMachine.CurrentState.GetType().Name;
        }

        private void OnEnable()
        {
            moneyInputSpot.SetActive(true);
            numberInputField.SetActive(true);
            moneyChangeSpot.SetActive(true);
            itemDispenseSpot.SetActive(true);
        }

        public void OnRequestIdleState()
        {
            if (stateMachine.CurrentState != vendingMachineIdleState && stateMachine.CurrentState == vendingMachineDispenseState)
            {
                stateMachine.ChangeState(vendingMachineIdleState);
                currentState = stateMachine.CurrentState.GetType().Name;
            }
        }

        public void OnRequestMoneyInputState()
        {
            if (stateMachine.CurrentState != vendingMachineMoneyInputState && stateMachine.CurrentState == vendingMachineIdleState)
            {
                StartCoroutine(SimulateMoneyInputState());
            }
        }
        
        public void OnRequestNumberInputState()
        {
            if (stateMachine.CurrentState != vendingMachineNumberInputState && stateMachine.CurrentState == vendingMachineMoneyInputState)
            {
                StopAllCoroutines();
                StartCoroutine(SimulateNumberInputState());
            }
        }

        public void OnRequestDispenseState()
        {
            if (stateMachine.CurrentState != vendingMachineDispenseState && 
                (stateMachine.CurrentState == vendingMachineNumberInputState || 
                 stateMachine.CurrentState == vendingMachineMoneyInputState))
            {
                StartCoroutine(SimulateDispenseState());
            }
        }
        
        private IEnumerator SimulateMoneyInputState()
        {
            stateMachine.ChangeState(vendingMachineMoneyInputState);
            currentState = stateMachine.CurrentState.GetType().Name;
            
            yield return new WaitForSeconds(8f);
            OnRequestDispenseState();
        }

        private IEnumerator SimulateNumberInputState()
        {
            stateMachine.ChangeState(vendingMachineNumberInputState);
            currentState = stateMachine.CurrentState.GetType().Name;
            
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                idleData.MessageText.Set("Bitte warten.");
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                idleData.MessageText.Set("Please wait.");
            }
            
            yield return new WaitForSeconds(2f);

            OnRequestDispenseState();
        }

        private IEnumerator SimulateDispenseState()
        {
            stateMachine.ChangeState(vendingMachineDispenseState);
            currentState = stateMachine.CurrentState.GetType().Name;
            
            yield return new WaitForSeconds(3f);

            OnRequestIdleState();
        }
    }
}