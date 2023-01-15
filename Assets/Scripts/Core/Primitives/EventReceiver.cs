using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Primitives
{
    public class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [Button]
        public void Call()
        {
            OnEvent?.Invoke();
        }
    }
}
