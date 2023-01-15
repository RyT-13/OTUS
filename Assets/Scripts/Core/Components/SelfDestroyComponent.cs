using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components
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
