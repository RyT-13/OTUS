using System;
using System.Collections;
using UnityEngine;

namespace Primitives
{
    public class PeriodBehaviour : MonoBehaviour
    {
        public event Action PeriodEvent;

        [SerializeField] private float _period = 1.0f;
        private Coroutine _coroutine;

        public bool IsPlaying => _coroutine is not null;

        public void Play()
        {
            _coroutine ??= StartCoroutine(PeriodRoutine());
        }

        public void Stop()
        {
            if (_coroutine is null) 
                return;
            
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator PeriodRoutine()
        {
            var period = new WaitForSeconds(_period);
            while (true)
            {
                yield return period;
                PeriodEvent?.Invoke();
            }
        }
    }
}
