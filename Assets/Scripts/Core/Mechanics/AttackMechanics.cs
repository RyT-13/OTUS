using Core.Components.Abstract;
using Core.Entities;
using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class AttackMechanics : MonoBehaviour
    {
        [SerializeField] private EntityEventReceiver _attackReceiver;
        [SerializeField] private TimerBehaviour _countdown;
        [SerializeField] private IntBehaviour _damage;
        
        private void OnEnable()
        {
            _attackReceiver.OnEvent += OnRequestAttack;
        }

        private void OnDisable()
        {
            _attackReceiver.OnEvent -= OnRequestAttack;
        }

        private void OnRequestAttack(Entity target)
        {
            if (_countdown.IsPlaying)
            {
                return;
            }
            
            target.GetComponent<ITakeDamageComponent>().TakeDamage(_damage.Value);
            
            _countdown.ResetTime();
            _countdown.Play();
        }
    }
}
