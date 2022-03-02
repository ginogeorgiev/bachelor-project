using DataStructures.StateLogic;
using UnityEngine.Localization.Settings;

namespace Features.StateLevel.Logic
{
    public class VendingMachineNumberInputState : BaseState
    {
        public VendingMachineNumberInputState(StateData data) : base(data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            if (Data.InMachineMoneyAmount.Get() > 0)
            {
                Data.InMachineMoneyAmount.Add(-1);
                Data.ItemAmount.Add(1);
            }
            
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                Data.MessageText.Set("Bitte Warten, Bestellung wird bearbeitet");
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                Data.MessageText.Set("Please wait, order is being processed.");
            }
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}