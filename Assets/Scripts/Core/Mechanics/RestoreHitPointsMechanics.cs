using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class RestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        [SerializeField] private IntBehaviour _hitPoints;
        [SerializeField] private TimerBehaviour _delay;
        [SerializeField] private PeriodBehaviour _restorePeriod;

        private void OnEnable()
        {
            _takeDamageReceiver.OnEvent += OnDamageTaken;
            _delay.OnFinished += OnDelayEnded;
            _restorePeriod.OnPeriodEvent += OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            _takeDamageReceiver.OnEvent -= OnDamageTaken;
            _delay.OnFinished -= OnDelayEnded;
            _restorePeriod.OnPeriodEvent -= OnRestoreHitPoints;
        }

        private void OnDamageTaken(int obj)
        {
            _delay.ResetTime();

            if (_delay.IsPlaying == false)
            {
                _delay.Play();
            }

            _restorePeriod.Stop();
        }

        private void OnDelayEnded()
        {
            _restorePeriod.Play();
        }

        private void OnRestoreHitPoints()
        {
            _hitPoints.Value++;
            if (_hitPoints.Value >= 5)
            {
                _restorePeriod.Stop();
            }
        }
    }
}
