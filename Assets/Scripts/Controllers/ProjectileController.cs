using Core.Components.Abstract;
using Core.Entities;
using UnityEngine;

namespace Controllers
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private Entity _unit;
        
        private ISelfDestroyComponent _selfDestroyComponent;
        private IMoveComponent _moveComponent;

        private void Awake()
        {
            _selfDestroyComponent = _unit.Get<ISelfDestroyComponent>();
            _moveComponent = _unit.Get<IMoveComponent>();
        }

        private void Start()
        {
            _selfDestroyComponent.StartDestruction();
        }

        private void Update()
        {
            _moveComponent.Move(transform.forward);
        }
    }
}
