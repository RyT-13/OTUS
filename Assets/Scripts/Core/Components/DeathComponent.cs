using System;
using Core.Components.Abstract;
using Core.Primitives;
using UnityEngine;

namespace Core.Components
{
    public class DeathComponent : MonoBehaviour, IDeathComponent
    {
        public event Action OnDie;

        [SerializeField] private EventReceiver _deathReceiver;

        private void OnEnable()
        {
            _deathReceiver.OnEvent += Die;
        }

        private void OnDisable()
        {
            _deathReceiver.OnEvent -= Die;
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
    }
}
