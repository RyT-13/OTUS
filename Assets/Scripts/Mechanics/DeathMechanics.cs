using System;
using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class DeathMechanics : MonoBehaviour
    {
        [SerializeField] private IntBehaviour _hitPoints;

        [SerializeField] private EventReceiver _deathReceiver;


        private void OnEnable()
        {
            _hitPoints.ValueChanged += OnHitPointsChanged;
        }

        private void OnDisable()
        {
            _hitPoints.ValueChanged -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                _deathReceiver.Call();
            }
        }
    }
}
