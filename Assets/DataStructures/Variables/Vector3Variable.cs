using UnityEngine;

namespace DataStructures.Variables
{
    [CreateAssetMenu(fileName = "newVector3Variable", menuName = "DataStructures/Variables/Vector3Variable")]
    public class Vector3Variable : AbstractVariable<Vector3>
    {
        public void Add(Vector3 value)
        {
            runtimeValue += value;
            if(onValueChanged != null) onValueChanged.Raise();
        }

        public void Add(Vector3Variable value)
        {
            runtimeValue += value.runtimeValue;
            if(onValueChanged != null) onValueChanged.Raise();
        }
    }
}

