using Mechanics;
using Primitives;
using UnityEngine;

namespace Entities
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _movementReceiver;
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
            _movementReceiver.Call(transform.forward);
        }
    }
}
