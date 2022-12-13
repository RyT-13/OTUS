﻿using System;
using GameState.Listeners;
using UnityEngine;

namespace Controllers
{
    public class KeyboardInput : MonoBehaviour, 
        IStartGameListener, IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        public event Action<Vector3> OnMove;
        public event Action OnJump;
        public event Action OnShoot;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            HandleKeyboard();
        }

        void IStartGameListener.OnStartGame()
        {
            TurnOnInput();
        }

        void IPauseGameListener.OnPauseGame()
        {
            TurnOffInput();
        }

        void IResumeGameListener.OnResumeGame()
        {
            TurnOnInput();
        }

        void IFinishGameListener.OnFinishGame()
        {
            TurnOffInput();
        }

        private void TurnOnInput()
        {
            enabled = true;
        }
        
        private void TurnOffInput()
        {
            enabled = false;
        }

        private void HandleKeyboard()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            var direction = new Vector3(x, 0, z);
            Move(direction);

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        private void Move(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                OnMove?.Invoke(direction);
            }
        }

        private void Jump()
        {
            OnJump?.Invoke();
        }

        private void Shoot()
        {
            OnShoot?.Invoke();
        }
    }
}
