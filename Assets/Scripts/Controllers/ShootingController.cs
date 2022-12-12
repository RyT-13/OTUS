using Components.Abstract;
using GameState;
using GameState.Abstract;
using Services;
using UnityEngine;

namespace Controllers
{
    public class ShootingController : MonoBehaviour, IConstructListener,
        IStartGameListener, IFinishGameListener
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
            _input.OnShoot += OnShoot;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _input.OnShoot -= OnShoot;
        }

        private void OnShoot()
        {
            _shootingComponent.Shoot();
        }
    }
}
