using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Primitives
{
    public class TimerBehaviour : MonoBehaviour
    {
        public event Action OnStarted;
        public event Action OnTimeChanged;
        public event Action OnFinished;

        [SerializeField] private float _duration = 3;
        [ReadOnly] [SerializeField] private float _currentTime;

        private Coroutine _timerCoroutine;

        public bool IsPlaying => _timerCoroutine is not null;

        public float Progress => _currentTime / _duration;

        public void Play()
        {
            if (_timerCoroutine is null)
            {
                ResetTime();
                OnStarted?.Invoke();
                _timerCoroutine = StartCoroutine(TimeRoutine());
            }
        }

        public void Stop()
        {
            if (_timerCoroutine is null)
                return;

            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }

        public void ResetTime()
        {
            _currentTime = 0;
        }

        private IEnumerator TimeRoutine()
        {
            while (_currentTime < _duration)
            {
                yield return null;
                _currentTime += Time.deltaTime;
                OnTimeChanged?.Invoke();
            }

            _currentTime = _duration;
            _timerCoroutine = null;

            OnFinished?.Invoke();
        }
    }
}
