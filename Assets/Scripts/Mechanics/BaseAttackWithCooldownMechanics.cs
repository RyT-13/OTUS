using Primitives;
using UnityEngine;

namespace Mechanics
{
    public abstract class BaseAttackWithCooldownMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehaviour _countdown;
        [SerializeField] private IntBehaviour _damage;

        protected abstract void OnAttack(int damage);

        private void OnEnable()
        {
            _attackReceiver.EventCalled += OnRequestAttack;
        }

        private void OnDisable()
        {
            _attackReceiver.EventCalled -= OnRequestAttack;
        }

        private void OnRequestAttack()
        {
            if (_countdown.IsPlaying)
            {
                return;
            }
            
            OnAttack(_damage.Value);
            
            _countdown.ResetTime();
            _countdown.Play();
        }
    }
}
