using Components.Abstract;
using Primitives;
using UnityEngine;

namespace Components
{
    public class ShootingComponent : MonoBehaviour, IShootingComponent
    {
        [SerializeField] private EventReceiver _attackReceiver;
        
        public void Shoot()
        {
            _attackReceiver.Call();
        }
    }
}
