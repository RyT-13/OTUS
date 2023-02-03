using Core.Primitives;
using UnityEngine;
using UnityEngine.Serialization;

namespace Visual.GameObjects
{
    public class ConveyorZoneVisualAdapter : MonoBehaviour
    {
        [SerializeField] private ConveyorZoneVisual _view;

        [SerializeField] private IntBehaviourLimited _storage;

        private void OnEnable()
        {
            _view.SetupItems(_storage.Value);
            _storage.OnValueChange += _view.SetupItems;
        }

        private void OnDisable()
        {
            _storage.OnValueChange -= _view.SetupItems;
        }
    }
}
