using System;
using UnityEngine;

namespace Core.Primitives
{
    public class IntBehaviour : MonoBehaviour
    {
        public event Action<int> OnValueChanged;

        [SerializeField] private int _value;
        
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
}
