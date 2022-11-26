using Mechanics;
using UnityEngine;

namespace Entities
{
    public class Projectile : MonoBehaviour
    {

        [SerializeField] private MovementMechanics _movementMechanics;
        [SerializeField] private DestroyWithDelayMechanics _destroyMechanics;

        private int _damage;

        public void Init(int damage)
        {
            _damage = damage;
        }

        private void Start()
        {
            _destroyMechanics.StartCountdown();
        }

        private void Update()
        {
            _movementMechanics.Move(transform.forward);
        }
    }
}
