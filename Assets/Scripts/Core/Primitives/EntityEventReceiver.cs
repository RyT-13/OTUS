using System;
using Core.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Primitives
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
