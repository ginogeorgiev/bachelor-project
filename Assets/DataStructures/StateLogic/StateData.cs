using DataStructures.Event;
using DataStructures.Variables;
using UnityEngine;

namespace DataStructures.StateLogic
{
    [CreateAssetMenu(fileName = "newStateData", menuName = "DataStructures/StateLogic/StateData")]
    public class StateData : ScriptableObject
    {
        [SerializeField] private BoolVariable isStateActive;
        
        // For UI State viewer
        [SerializeField] private GameObject enterStateText;
        [SerializeField] private GameObject exitStateText;
        
        // For UI Messages
        [SerializeField] private StringVariable messageText;

        // Enter-/Exit-Events of states
        [SerializeField] private OnStateEnterEvent onEnterEventEvent;
        [SerializeField] private OnStateExitEvent onExitEventEvent;

        [SerializeField] private IntVariable playerMoneyAmount;
        [SerializeField] private IntVariable inMachineMoneyAmount;
        [SerializeField] private IntVariable moneyChangeAmount;
        [SerializeField] private IntVariable itemAmount;

        [SerializeField] private GameEvent_SO spawnCoin;
        [SerializeField] private GameEvent_SO spawnItem;

        public BoolVariable IsStateActive => isStateActive;
        public GameObject EnterStateText => enterStateText;
        public GameObject ExitStateText => exitStateText;

        public StringVariable MessageText => messageText;

        public OnStateEnterEvent OnEnterEventEvent => onEnterEventEvent;
        public OnStateExitEvent OnExitEventEvent => onExitEventEvent;

        public IntVariable PlayerMoneyAmount => playerMoneyAmount;
        public IntVariable InMachineMoneyAmount => inMachineMoneyAmount;
        public IntVariable MoneyChangeAmount => moneyChangeAmount;
        public IntVariable ItemAmount => itemAmount;

        public GameEvent_SO SpawnCoin => spawnCoin;

        public GameEvent_SO SpawnItem => spawnItem;
    }
}