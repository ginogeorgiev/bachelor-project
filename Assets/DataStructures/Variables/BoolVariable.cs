using UnityEngine;

namespace DataStructures.Variables
{
    [CreateAssetMenu(fileName = "newBoolVariable", menuName = "DataStructures/Variables/BoolVariable")]
    public class BoolVariable : AbstractVariable<bool>
    {
        public void SetTrue()
        {
            Set(true);
        }

        public void SetFalse()
        {
            Set(false);
        }
    }
}