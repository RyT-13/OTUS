using System;
using Core.Components.Abstract.GameObjects;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.GameObjects
{
    public class WorkComponent : MonoBehaviour, IWorkComponent
    {
        public event Action OnStartWork
        {
            add => _timer.OnStarted += value;
            remove => _timer.OnStarted -= value;
        }

        public event Action<float> OnProgress;
        
        public event Action OnFinishWork
        {
            add => _timer.OnFinished += value;
            remove => _timer.OnFinished -= value;
        }

        public bool IsWorking => _timer.IsPlaying;
        public float Progress => _timer.Progress;

        [SerializeField] private TimerBehaviour _timer;

        private void OnEnable()
        {
            _timer.OnTimeChanged += OnProgressChanged;
        }

        private void OnDisable()
        {
            _timer.OnTimeChanged -= OnProgressChanged;
        }

        private void OnProgressChanged()
        {
            OnProgress?.Invoke(Progress);
        }
    }
}
