using Components.Abstract;
using Entities;
using Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [SerializeField] private EntityEventReceiver _attackReceiver;

        [Button]
        public void Attack(Entity target)
        {
            _attackReceiver.Call(target);
        }
    }
}
