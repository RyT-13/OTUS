using System.Collections;
using Primitives;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public class JumpMechanics : MonoBehaviour
    {
        [SerializeField] private Transform _jumpingObject;

        [SerializeField] private IntBehaviour _maxHeight;
        [SerializeField] private IntBehaviour _speed;

        [SerializeField] private AnimationCurve _curve;
        
        private bool _inJump;

        [Button]
        public void Jump()
        {
            if (_inJump)
                return;

            StartCoroutine(JumpRoutine());
        }

        private IEnumerator JumpRoutine()
        {
            _inJump = true;
            var progress = 0f;

            while (progress < 1)
            {
                var height = _curve.Evaluate(progress) * _maxHeight.Value;
                progress += _speed.Value * Time.deltaTime;

                SetHeight(height);
                
                yield return null;
            }
            
            SetHeight(0);
            _inJump = false;
        }

        private void SetHeight(float height)
        {
            var currentPosition = _jumpingObject.position;
            currentPosition.y = height;
            _jumpingObject.position = currentPosition;
        }
    }
}
