using Components.Abstract;
using GameState;
using GameState.Abstract;
using Services;
using UnityEngine;

namespace Controllers
{
    public class MoveController : MonoBehaviour, IConstructListener,
        IStartGameListener, IFinishGameListener
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
            _input.OnMove += OnMove;
            _input.OnJump += OnJump;
        }

        void IFinishGameListener.OnFinishGame()
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
