using DataStructures.StateLogic;
using UnityEngine.Localization.Settings;

namespace Features.StateLevel.Logic
{
    public class VendingMachineIdleState : BaseState
    {
        public VendingMachineIdleState(StateData data) : base(data)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[1])
            {
                Data.MessageText.Set("Bitte geben Sie Geld ein.");
            }
            else if (LocalizationSettings.SelectedLocale == LocalizationSettings.AvailableLocales.Locales[0])
            {
                Data.MessageText.Set("Please insert money.");
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