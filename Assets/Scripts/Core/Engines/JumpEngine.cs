using System.Collections;
using UnityEngine;

namespace Core.Engines
{
    public class JumpEngine : MonoBehaviour
    {
        [SerializeField] private Transform _jumpingObject;
        [SerializeField] private AnimationCurve _curve;
        
        private bool _inJump;

        public void Jump(int speed, int height)
        {
            if (_inJump)
                return;

            StartCoroutine(JumpRoutine(speed, height));
        }

        private IEnumerator JumpRoutine(int speed, int maxHeight)
        {
            _inJump = true;
            var progress = 0f;

            while (progress < 1)
            {
                var height = _curve.Evaluate(progress) * maxHeight;
                progress += speed * Time.deltaTime;

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
