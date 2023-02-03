using System;
using UnityEngine;

namespace Core.Primitives
{
    public class IntBehaviourLimited : MonoBehaviour
    {
        public event Action<int> OnValueChange;
        
        [SerializeField] private int _currentValue;
        [SerializeField] private int _maxValue;

        public int Value
        {
            get => _currentValue;
            set
            {
                _currentValue = Mathf.Clamp(value, 0, _maxValue);
                OnValueChange?.Invoke(_currentValue);
            }
        }

        public int MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value; 
                _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
            }
        }

        public bool IsLimit => _currentValue >= _maxValue;
    }
}
