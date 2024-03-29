﻿using System;
using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;

        private void OnEnable()
        {
            _takeDamageReceiver.EventCalled += OnDamageTaken;
        }

        private void OnDisable()
        {
            _takeDamageReceiver.EventCalled -= OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            _hitPoints.Value -= damage;
        }
    }
}
