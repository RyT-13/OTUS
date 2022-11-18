using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> EventCalled;

        [Button]
        public void Call(int value)
        {
            EventCalled?.Invoke(value);
        }
    }
}
