using UnityEngine;

namespace DataStructures.Variables
{
    [CreateAssetMenu(fileName = "newVector2Variable", menuName = "DataStructures/Variables/Vector2Variable")]
    public class Vector2Variable : AbstractVariable<Vector2>
    {
        public void Add(Vector2 value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(Vector2Variable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}

