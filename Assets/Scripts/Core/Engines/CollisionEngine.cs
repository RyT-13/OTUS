using Core.Primitives;
using UnityEngine;

namespace Core.Engines
{
    public class CollisionEngine : MonoBehaviour
    {
        [SerializeField] private EventReceiver _collisionReceiver;
        
        private void OnCollisionEnter(Collision collision)
        {
            _collisionReceiver.Call();
        }
    }
}
