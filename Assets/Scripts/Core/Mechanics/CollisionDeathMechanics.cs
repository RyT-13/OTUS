using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class CollisionDeathMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _collisionReceiver;
        [SerializeField] private EventReceiver _deathReceiver;

        private void OnEnable()
        {
            _collisionReceiver.OnEvent += OnCollision;
        }

        private void OnDisable()
        {
            _collisionReceiver.OnEvent -= OnCollision;
        }

        private void OnCollision()
        {
            _deathReceiver.Call();
        }
    }
}
