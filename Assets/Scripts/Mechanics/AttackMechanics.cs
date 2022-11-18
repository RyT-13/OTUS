using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class AttackMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehaviour _countdown;
        [SerializeField] private IntBehaviour _damage;

        [Space] [SerializeField] private Enemy _enemy;

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
            
            _enemy.TakeDamage(_damage.Value);
            
            _countdown.ResetTime();
            _countdown.Play();
        }
    }
}
