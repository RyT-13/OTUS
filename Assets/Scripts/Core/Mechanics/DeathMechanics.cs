using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class DeathMechanics : MonoBehaviour
    {
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private EventReceiver _deathReceiver;
        
        private void OnEnable()
        {
            _hitPoints.OnValueChanged += OnHitPointsChanged;
        }

        private void OnDisable()
        {
            _hitPoints.OnValueChanged -= OnHitPointsChanged;
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
