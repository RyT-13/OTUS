using Components.Abstract;
using Entities;
using UnityEngine;

namespace Controllers
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private Entity _unit;

        private IMoveComponent _moveComponent;
        private IJumpComponent _jumpComponent;
        private IShootingComponent _shootingComponent;
        
        private void Awake()
        {
            _moveComponent = _unit.Get<IMoveComponent>();
            _jumpComponent = _unit.Get<IJumpComponent>();
            _shootingComponent = _unit.Get<IShootingComponent>();
        }

        private void Update()
        {
            HandleKeyboard();
        }

        private void HandleKeyboard()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var direction = new Vector3(x, 0, z);
            Move(direction);

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void Move(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                _moveComponent.Move(direction);
            }
        }

        private void Jump()
        {
            _jumpComponent.Jump();
        }

        private void Shoot()
        {
            _shootingComponent.Shoot();
        }
    }
}
