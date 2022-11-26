using Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public class MovementMechanics : MonoBehaviour
    {
        [SerializeField] private Transform _movingObject;
        
        [SerializeField] private IntBehaviour _speed;

        [Button]
        public void Move(Vector3 direction)
        {
            direction.y = 0;
            var dir = direction.normalized;
            
            _movingObject.position += dir * (_speed.Value * Time.deltaTime);
        }
    }
}
