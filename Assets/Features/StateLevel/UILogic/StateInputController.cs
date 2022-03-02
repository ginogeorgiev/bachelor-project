using System.Collections.Generic;
using DataStructures.Event;
using DataStructures.Variables;
using Features.StateLevel.Logic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Features.StateLevel.UILogic
{
    public class StateInputController : MonoBehaviour
    {
        [SerializeField] private VendingMachineStateHandler vendingMachineStateHandler;

        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private Transform coinParent;

        [SerializeField] private List<GameObject> dispenseItemPrefabs;
        [SerializeField] private Transform dispenseItemParent;

        [SerializeField] private IntVariable playerMoneyAmount;
        [SerializeField] private IntVariable inMachineMoneyAmount;
        [SerializeField] private IntVariable moneyChangeAmount;
        [SerializeField] private IntVariable itemAmount;
        
        [SerializeField] private BoolVariable isItemCollected;

        private void Awake()
        {
            playerMoneyAmount.Restore();
            inMachineMoneyAmount.Restore();
            moneyChangeAmount.Restore();
            itemAmount.Restore();
        }

        public void OnMoneyInputSpotClicked()
        {
            if (playerMoneyAmount.Get() > 0)
            {
                vendingMachineStateHandler.OnRequestMoneyInputState();
            }
        }
        
        public void OnNumberInputFieldClicked()
        {
            vendingMachineStateHandler.OnRequestNumberInputState();
        }

        public void OnMoneyChangeSpotClicked()
        {
            if (moneyChangeAmount.Get() > 0)
            {
                moneyChangeAmount.Add(-1);
                playerMoneyAmount.Add(1);
                if (coinParent.childCount != 0) Destroy(coinParent.GetChild(0).gameObject);
            }
        }

        public void OnItemDispenseSpotClicked()
        {
            if (itemAmount.Get() > 0)
            {
                itemAmount.Add(-1);
                if (dispenseItemParent.childCount != 0)
                {
                    Destroy(dispenseItemParent.GetChild(0).gameObject);
                    isItemCollected.SetTrue();
                }
            }
        }

        public void OnSpawnCoin()
        {
            if (coinPrefab == null) return;
            GameObject coin = Instantiate(coinPrefab, coinParent);
            coin.transform.localPosition = new Vector3(Random.Range(-0.14f, 0.18f), 0, 0);
        }

        public void OnSpawnItem()
        {
            if (dispenseItemPrefabs.Count == 0 || dispenseItemPrefabs == null) return;
            GameObject item = Instantiate(dispenseItemPrefabs[Random.Range(dispenseItemPrefabs.Count - 1, 0)], dispenseItemParent);
            item.transform.localPosition = new Vector3(Random.Range(-0.9f, 0.83f), 0, 0);
        }
    }
}