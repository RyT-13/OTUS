using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _components = new List<MonoBehaviour>();

        public T Get<T>()
        {
            foreach (var component in _components)
            {
                if (component is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Component of type {typeof(T).Name} is not found!");
        }

        public bool TryGet<T>(out T result)
        {
            foreach (var component in _components)
            {
                if (component is T tComponent)
                {
                    result = tComponent;
                    return true;
                }
            }

            result = default;
            return false;
        }
        
    }
}
