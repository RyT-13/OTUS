using Components.Abstract;
using GameState;
using GameState.Listeners;
using Services;
using UnityEngine;

namespace Controllers
{
    public class DeathController : MonoBehaviour, IConstructListener,
        IStartGameListener, IFinishGameListener
    {
        private GameContext _context;
        private IDeathComponent _deathComponent;
        
        public void Construct(GameContext context)
        {
            _context = context;
            
            var character = context.GetService<CharacterService>().GetCharacter();
            _deathComponent = character.Get<IDeathComponent>();
        }

        void IStartGameListener.OnStartGame()
        {
            _deathComponent.OnDie += OnDie;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _deathComponent.OnDie -= OnDie;

        }

        private void OnDie()
        {
            _context.FinishGame();
        }
    }
}
