using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Primitives
{
    public class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 vector)
        {
            OnEvent?.Invoke(vector);
        }
    }
}
