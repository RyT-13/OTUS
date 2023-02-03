using System;
using Core.Primitives;
using UnityEngine;

namespace Visual.GameObjects
{
    public class ConveyorWidgetAdapter : MonoBehaviour
    {
        [SerializeField] private ConveyorWidget _view;

        [SerializeField] private TimerBehaviour _timer;

        private void OnEnable()
        {
            _timer.OnStarted += OnWorkStarted;
            _timer.OnTimeChanged += OnWorkProgress;
            _timer.OnFinished += OnWorkFinished;
            
            _view.SetVisible(false);
        }

        private void OnDisable()
        {
            _timer.OnStarted -= OnWorkStarted;
            _timer.OnTimeChanged -= OnWorkProgress;
            _timer.OnFinished -= OnWorkFinished;
        }

        private void OnWorkStarted()
        {
            _view.SetVisible(true);
        }

        private void OnWorkProgress()
        {
            _view.SetProgress(_timer.Progress);
        }

        private void OnWorkFinished()
        {
            _view.SetVisible(false);
        }
    }
}
