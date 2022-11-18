using System;
using UnityEngine;

namespace Primitives
{
    public class IntBehaviour : MonoBehaviour
    {
        public event Action<int> ValueChanged;

        [SerializeField] private int _value;
        
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Invoke(value);
            }
        }
    }
}
