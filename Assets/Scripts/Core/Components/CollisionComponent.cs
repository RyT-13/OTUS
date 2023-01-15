using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components
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
