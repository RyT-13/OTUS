using Core.Components.Abstract;
using Core.Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private Vector3EventReceiver _moveReceiver;
        
        [Button]
        public void Move(Vector3 direction)
        {
            _moveReceiver.Call(direction);
        }
    }
}
