using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics.GameObjects
{
    public class ConveyorDoubleWorkMechanics : MonoBehaviour
    {
        [SerializeField] private TimerBehaviour _workTimer;

        [SerializeField] private IntBehaviourLimited _firstInputStorage;
        [SerializeField] private IntBehaviourLimited _secondInputStorage;
        [SerializeField] private IntBehaviourLimited _outputStorage;

        private void OnEnable()
        {
            _workTimer.OnFinished += OnFinished;
        }

        private void OnDisable()
        {
            _workTimer.OnFinished -= OnFinished;
        }

        private void Update()
        {
            if (CanStartWork())
            {
                StartWork();
            }
        }

        private bool CanStartWork()
        {
            if (_firstInputStorage.Value <= 0 || _secondInputStorage.Value <= 0)
            {
                return false;
            }

            if (_outputStorage.IsLimit)
            {
                return false;
            }

            if (_workTimer.IsPlaying)
            {
                return false;
            }

            return true;
        }

        private void StartWork()
        {
            _firstInputStorage.Value--;
            _secondInputStorage.Value--;
            _workTimer.Play();
        }

        private void OnFinished()
        {
            _outputStorage.Value++;
        }
    }
}
