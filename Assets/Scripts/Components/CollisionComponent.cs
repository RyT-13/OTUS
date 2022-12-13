using Components.Abstract;
using Primitives;
using UnityEngine;

namespace Components
{
    public class CollisionComponent : MonoBehaviour, ICollisionComponent
    {
        [SerializeField] private EventReceiver _collisionReceiver;
        
        public void Collision()
        {
            _collisionReceiver.Call();
        }
    }
}
