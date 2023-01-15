using Core.Components.Abstract;
using Core.Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Components
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;

        [Button]
        public void TakeDamage(int damage)
        {
            _takeDamageReceiver.Call(damage);
        }
    }
}
