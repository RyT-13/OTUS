using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Primitives
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> EventCalled;

        [Button]
        public void Call(Vector3 vector)
        {
            EventCalled?.Invoke(vector);
        }
    }
}
