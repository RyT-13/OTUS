using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Primitives
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void SetProgress(float progress)
        {
            _fillImage.fillAmount = progress;
        }
    }
}
