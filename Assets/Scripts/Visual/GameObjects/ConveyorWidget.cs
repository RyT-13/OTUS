using UI;
using UI.Primitives;
using UnityEngine;

namespace Visual.GameObjects
{
    public class ConveyorWidget : MonoBehaviour
    {
        [SerializeField] private GameObject _root;

        [SerializeField] private ProgressBar _progressBar;

        public void SetProgress(float progress)
        {
            _progressBar.SetProgress(progress);
        }

        public void SetVisible(bool isVisible)
        {
            _root.SetActive(isVisible);
        }
    }
}
