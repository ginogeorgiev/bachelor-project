using DataStructures.StateLogic;
using UnityEngine.Localization.Settings;

namespace Features.StateLevel.Logic
{
    public class VendingMachineMoneyInputState : BaseState
    { 
        public VendingMachineMoneyInputState(StateData data) : base(data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            Data.PlayerMoneyAmount.Add(-1);
            Data.InMachineMoneyAmount.Add(1);
            
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                Data.MessageText.Set("Bitte geben Sie ihre Produktnummer ein.");
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                Data.MessageText.Set("Please insert a product number.");
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