using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Popups
{
    public class PopupManager : MonoBehaviour, ICallback
    {
        [SerializeField] private PopupHolder[] _allPopups;

        private readonly Dictionary<PopupName, Popup> _activePopups = new();

        private void Awake()
        {
            foreach (var popupHolder in _allPopups)
            {
                popupHolder.Popup.gameObject.SetActive(false);
            }
        }

        [Title("Methods")]
        [Button]
        public void ShowPopup(PopupName popupName, object args = null)
        {
            if (IsPopupActive(popupName))
            {
                return;
            }

            var popup = FindPopup(popupName);
            popup.gameObject.SetActive(true);
            popup.Show(args, this);
            
            _activePopups.Add(popupName, popup);
        }

        [Button]
        public void HidePopup(PopupName popupName)
        {
            if (IsPopupActive(popupName) == false)
            {
                return;
            }

            var popup = _activePopups[popupName];
            popup.Hide();
            popup.gameObject.SetActive(false);

            _activePopups.Remove(popupName);
        }
        

        void ICallback.OnClosePopup(Popup popup)
        {
            var popupName = FindName(popup);
            HidePopup(popupName);
        }

        private PopupName FindName(Popup popup)
        {
            foreach (var holder in _allPopups)
            {
                if (ReferenceEquals(holder.Popup, popup))
                {
                    return holder.Name;
                }
            }

            throw new Exception($"Name of popup {popup.name} is not found!");
        }

        private bool IsPopupActive(PopupName popupName)
        {
            return _activePopups.ContainsKey(popupName);
        }

        private Popup FindPopup(PopupName popupName)
        {
            foreach (var holder in _allPopups)
            {
                if (holder.Name == popupName)
                {
                    return holder.Popup;
                }
            }

            throw new Exception($"Popup with name {name} is not found!");
        }
    }
}
