using Core.Engines;
using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _jumpReceiver;
        [SerializeField] private JumpEngine _jumpEngine;
        [SerializeField] private IntBehaviour _speed;
        [SerializeField] private IntBehaviour _height;

        private void OnEnable()
        {
            _jumpReceiver.OnEvent += OnJumpRequest;
        }

        private void OnDisable()
        {
            _jumpReceiver.OnEvent -= OnJumpRequest;
        }

        private void OnJumpRequest()
        {
            _jumpEngine.Jump(_speed.Value, _height.Value);
        }
    }
}
