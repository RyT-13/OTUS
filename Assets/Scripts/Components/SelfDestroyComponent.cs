using Components.Abstract;
using Mechanics;
using Primitives;
using UnityEngine;

namespace Components
{
    public class SelfDestroyComponent : MonoBehaviour, ISelfDestroyComponent
    {
        [SerializeField] private EventReceiver _destroyReceiver;
        
        public void StartDestruction()
        {
            _destroyReceiver.Call();
        }
    }
}
