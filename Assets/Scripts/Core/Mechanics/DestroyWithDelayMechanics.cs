using Core.Primitives;
using UnityEngine;

namespace Core.Mechanics
{
    public class DestroyWithDelayMechanics : MonoBehaviour
    {
        [SerializeField] private EventReceiver _destructionReceiver;
        [SerializeField] private TimerBehaviour _delay;
        [SerializeField] private GameObject _destroyableObject;

        private void OnEnable()
        {
            _destructionReceiver.OnEvent += StartCountdown;
            _delay.OnFinished += OnDestroyObject;
        }

        private void OnDisable()
        {
            _destructionReceiver.OnEvent -= StartCountdown;
            _delay.OnFinished -= OnDestroyObject;

        }

        private void StartCountdown()
        {
            _delay.Play();
        }

        private void OnDestroyObject()
        {
            Destroy(_destroyableObject);
        }
    }
}
