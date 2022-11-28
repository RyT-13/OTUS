using Components.Abstract;
using Primitives;
using UnityEngine;

namespace Components
{
    public class DamageValueComponent : MonoBehaviour, IDamageValueComponent
    {
        [SerializeField] private IntBehaviour _damage;

        public int Get()
        {
            return _damage.Value;
        }

        public void Set(int value)
        {
            _damage.Value = value;
        }
    }
}
