using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
        public class EventReceiver : MonoBehaviour
        {
                public event Action EventCalled;

                [Button]
                public void Call()
                {
                        Debug.Log($"Event {name} was received...");
                        EventCalled?.Invoke();
                }
        }
}
