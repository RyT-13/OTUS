using System;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class EntityEventReceiver : MonoBehaviour
    {
        public event Action<Entity> OnEvent;
        
        [Button]
        public void Call(Entity entity)
        {
            OnEvent?.Invoke(entity);
        }
    }
}
