using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components
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
