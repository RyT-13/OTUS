using Components.Abstract;
using GameState;
using GameState.Listeners;
using Services;
using UnityEngine;

namespace Controllers
{
    public class MoveController : MonoBehaviour, IConstructListener,
        IStartGameListener, IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        private KeyboardInput _input;
        
        private IMoveComponent _moveComponent;
        private IJumpComponent _jumpComponent;

        void IConstructListener.Construct(GameContext context)
        {
            _input = context.GetService<KeyboardInput>();
            
            var character = context.GetService<CharacterService>().GetCharacter();
            _moveComponent = character.Get<IMoveComponent>();
            _jumpComponent = character.Get<IJumpComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            SubscribeToEvents();
        }
        
        void IPauseGameListener.OnPauseGame()
        {
            UnsubscribeFromEvents();
        }

        void IResumeGameListener.OnResumeGame()
        {
            SubscribeToEvents();
        }

        void IFinishGameListener.OnFinishGame()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            _input.OnMove += OnMove;
            _input.OnJump += OnJump;
        }
        
        private void UnsubscribeFromEvents()
        {
            _input.OnMove -= OnMove;
            _input.OnJump -= OnJump;
        }

        private void OnMove(Vector3 direction)
        {
            _moveComponent.Move(direction);
        }

        private void OnJump()
        {
            _jumpComponent.Jump();
        }
    }
}
