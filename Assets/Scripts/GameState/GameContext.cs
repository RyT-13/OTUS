using System;
using System.Collections.Generic;
using GameState.Listeners;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameState
{
    public class GameContext : MonoBehaviour
    {
        private readonly List<object> _listeners = new();

        private readonly List<object> _services = new();

        #region Listeners

        public void AddListener(object listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            _listeners.Remove(listener);
        }

        #endregion

        #region Services

        public void AddService(object service)
        {
            _services.Add(service);
        }

        public void RemoveService(object service)
        {
            _services.Remove(service);
        }

        public T GetService<T>()
        {
            foreach (var service in _services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T).Name} is not found.");
        }

        #endregion

        #region Game Events

        [Button]
        public void ConstructGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IConstructListener constructListener)
                {
                    constructListener.Construct(this);
                }
            }

            Debug.Log("Game constructed.");
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            Debug.Log("Game started.");
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IPauseGameListener startListener)
                {
                    startListener.OnPauseGame();
                }
            }

            Debug.Log("Game paused.");
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IResumeGameListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }

            Debug.Log("Game resumed.");
        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in _listeners)
            {
                if (listener is IFinishGameListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }

            Debug.Log("Game finished.");
        }

        #endregion
    }
}
