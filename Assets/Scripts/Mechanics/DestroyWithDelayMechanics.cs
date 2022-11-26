using Primitives;
using UnityEngine;

namespace Mechanics
{
    public class DestroyWithDelayMechanics : MonoBehaviour
    {
        [SerializeField] private TimerBehaviour _delay;
        [SerializeField] private GameObject _destroyableObject;

        private void OnEnable()
        {
            _delay.TimerEnded += OnDestroyObject;
        }

        private void OnDisable()
        {
            _delay.TimerEnded -= OnDestroyObject;

        }

        public void StartCountdown()
        {
            _delay.Play();
        }

        private void OnDestroyObject()
        {
            Destroy(_destroyableObject);
        }
    }
}
