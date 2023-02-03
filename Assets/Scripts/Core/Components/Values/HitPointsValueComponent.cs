using Core.Components.Abstract.Values;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.Values
{
    public class HitPointsValueComponent : MonoBehaviour, IHitPointsValueComponent
    {
        [SerializeField] private IntBehaviour _hitPoints;

        public int GetValue()
        {
            return _hitPoints.Value;
        }

        public void SetValue(int value)
        {
            _hitPoints.Value = value;
        }
    }
}
