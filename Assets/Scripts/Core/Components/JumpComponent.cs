using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components
{
    public class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField] private EventReceiver _jumpReceiver;

        public void Jump()
        {
            _jumpReceiver.Call();
        }
    }
}
