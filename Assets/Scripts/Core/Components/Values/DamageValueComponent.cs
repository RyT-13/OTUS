using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.Values
{
    public class DamageValueComponent : MonoBehaviour, IDamageValueComponent
    {
        [SerializeField] private IntBehaviour _damage;

        public int GetValue()
        {
            return _damage.Value;
        }

        public void SetValue(int value)
        {
            _damage.Value = value;
        }
    }
}
