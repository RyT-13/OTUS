using Primitives;
using UnityEngine;

namespace GameState
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameContext _context;
        [SerializeField] private TimerBehaviour _startGameTimer;

        private void OnEnable()
        {
            _startGameTimer.OnTimerEnded += StartGame;
        }

        private void OnDisable()
        {
            _startGameTimer.OnTimerEnded -= StartGame;
        }

        private void Start()
        {
            _context.ConstructGame();
            
            _startGameTimer.Play();
        }

        private void StartGame()
        {
            _context.StartGame();
        }
    }
}
