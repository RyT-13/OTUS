using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.Values
{
    public class MoveSpeedValueComponent : MonoBehaviour, IMoveSpeedValueComponent
    {
        [SerializeField] private IntBehaviour _speed;

        public int GetValue()
        {
            return _speed.Value;
        }

        public void SetValue(int value)
        {
            _speed.Value = value;
        }
    }
}
