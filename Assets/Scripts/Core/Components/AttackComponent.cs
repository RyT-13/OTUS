using Core.Components.Abstract;
using Core.Entities;
using Core.Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Components
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
