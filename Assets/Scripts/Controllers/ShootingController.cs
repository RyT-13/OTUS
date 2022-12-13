using Components.Abstract;
using GameState;
using GameState.Listeners;
using Services;
using UnityEngine;

namespace Controllers
{
    public class ShootingController : MonoBehaviour, IConstructListener,
        IStartGameListener, IFinishGameListener, IPauseGameListener, IResumeGameListener
    {
        private KeyboardInput _input;

        private IShootingComponent _shootingComponent;

        void IConstructListener.Construct(GameContext context)
        {
            _input = context.GetService<KeyboardInput>();
            
            var character = context.GetService<CharacterService>().GetCharacter();
            _shootingComponent = character.Get<IShootingComponent>();
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
            _input.OnShoot += OnShoot;
        }

        private void UnsubscribeFromEvents()
        {
            _input.OnShoot -= OnShoot;
        }

        private void OnShoot()
        {
            _shootingComponent.Shoot();
        }
    }
}
