using Primitives;
using UnityEngine;

namespace Engines
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
