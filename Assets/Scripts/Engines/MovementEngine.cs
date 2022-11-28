using UnityEngine;

namespace Engines
{
    public class MovementEngine : MonoBehaviour
    {
        [SerializeField] private Transform _movingObject;
        
        public void Move(Vector3 direction, int speed)
        {
            direction.y = 0;
            var dir = direction.normalized;
            
            _movingObject.position += dir * (speed * Time.deltaTime);
        }
    }
}
