using DataStructures.StateLogic;
using UnityEngine.Localization.Settings;

namespace Features.StateLevel.Logic
{
    public class VendingMachineDispenseState : BaseState
    {
        public VendingMachineDispenseState(StateData data) : base(data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();

            if (Data.InMachineMoneyAmount.Get() > 0)
            {
                Data.InMachineMoneyAmount.Add(-1);
                Data.MoneyChangeAmount.Add(1);
                Data.SpawnCoin.Raise();
            }

            if (Data.ItemAmount.Get() > 0 && Data.MoneyChangeAmount.Get() > 0)
            {
                if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
                {
                    Data.MessageText.Set("Vielen Dank!\nBitte entnehmen Sie ihre Ware und Wechselgeld.");
                }
                else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
                {
                    Data.MessageText.Set("Thank You!\nPlease take your product and change.");
                }
            }
            else if (Data.ItemAmount.Get() > 0 && Data.MoneyChangeAmount.Get() == 0)
            {
                if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
                {
                    Data.MessageText.Set("Vielen Dank!\nBitte entnehmen Sie ihre Ware.");
                    Data.SpawnItem.Raise();
                }
                else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
                {
                    Data.MessageText.Set("Thank You!\nPlease take your product.");
                    Data.SpawnItem.Raise();
                }
            }
            else if (Data.ItemAmount.Get() == 0 && Data.MoneyChangeAmount.Get() > 0)
            {
                if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
                {
                    Data.MessageText.Set("Vorgang wurde Abgebrochen!\nBitte entnehmen Sie ihr Geld");
                }
                else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
                {
                    Data.MessageText.Set("Process canceled!\nPlease take your change.");
                }
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