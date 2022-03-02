using DataStructures.Variables;
using UnityEngine;

namespace Features.Dialogue.UILogic
{
    public class DialogueEventListener : MonoBehaviour
    {
        [SerializeField] private BoolVariable glassesAreCollected;
        
        [SerializeField] private BoolVariable commandLvlWithGlassesCompleted;
        [SerializeField] private BoolVariable stateLvlWithGlassesCompleted;
        
        public void OnCommandLvlWithGlassesCompleted()
        {
            if (glassesAreCollected.Get())
            {
                commandLvlWithGlassesCompleted.SetTrue();
            }
        }
        
        public void OnStateLvlWithGlassesCompleted()
        {
            if (glassesAreCollected.Get())
            {
                stateLvlWithGlassesCompleted.SetTrue();
            }
        }
    }
}
