using Engines;
using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        [SerializeField] private MovementEngine _movementEngine;
        [SerializeField] private IntBehaviour _speed;


        private void OnEnable()
        {
            _moveReceiver.OnEvent += OnMoveRequest;
        }

        private void OnDisable()
        {
            _moveReceiver.OnEvent -= OnMoveRequest;
        }

        private void OnMoveRequest(Vector3 direction)
        {
            _movementEngine.Move(direction, _speed.Value);
        }
    }
}
