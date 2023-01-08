using UnityEngine;

namespace UI.Popups
{
    public class Popup : MonoBehaviour
    {
        private ICallback _callback;

        public void Show(object args = null, ICallback callback = null)
        {
            _callback = callback;
            OnShow(args);
        }

        public void Hide()
        {
            OnHide();
        }

        protected virtual void OnShow(object args)
        {
        }

        protected virtual void OnHide()
        {
        }

        public void RequestClose()
        {
            _callback?.OnClosePopup(this);
        }
    }
}
