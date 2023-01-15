using Core.Components.Abstract;
using Core.Entities;
using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class ShootingMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _attackReceiver;
        [SerializeField] private TimerBehaviour _countdown;
        [SerializeField] private IntBehaviour _damage;
        
        [Space] [SerializeField] private Entity _projectilePref;
        [SerializeField] private Transform _shootPoint;
        
        private void OnEnable()
        {
            _attackReceiver.OnEvent += OnRequestAttack;
        }

        private void OnDisable()
        {
            _attackReceiver.OnEvent -= OnRequestAttack;
        }

        private void OnRequestAttack()
        {
            if (_countdown.IsPlaying)
            {
                return;
            }
            
            var projectile = Instantiate(_projectilePref, _shootPoint.position, _shootPoint.rotation);
            projectile.Get<IDamageValueComponent>().SetValue(_damage.Value);
            
            _countdown.ResetTime();
            _countdown.Play();
        }
    }
}
