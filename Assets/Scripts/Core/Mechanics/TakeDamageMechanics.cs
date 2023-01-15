using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;

        private void OnEnable()
        {
            _takeDamageReceiver.OnEvent += OnDamageTaken;
        }

        private void OnDisable()
        {
            _takeDamageReceiver.OnEvent -= OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            _hitPoints.Value -= damage;
        }
    }
}
