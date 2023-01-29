using System.Collections;
using System.Linq;
using GameData.Character;
using GameData.Money;
using Modules.Services;
using Modules.Services.DI;
using Modules.Services.Installer;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace GameState.Application
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField]
        private ServiceInstaller serviceInstaller;

        [SerializeField] private AssetReference _gameScene;
        // [SerializeField] private AssetReference _uiScene;
        
        private bool _applicationLoaded;

        private GameContext _mainGameContext;
        // private GameContext _uiGameContext;

        [Button]
        public void LoadApplication()
        {
            if (!_applicationLoaded)
            {
                StartCoroutine(LoadRoutine());
            }
        }

        private IEnumerator LoadRoutine()
        {
            InstallServices();
            yield return LoadGameScene();
            LoadGameData();
            StartGame();
            _applicationLoaded = true;
        }

        private void InstallServices()
        {
            serviceInstaller.InstallServices();
            ServiceInjector.ResolveDependencies();
        }

        private IEnumerator LoadGameScene()
        {
            var operation = Addressables.LoadSceneAsync(_gameScene, LoadSceneMode.Additive);
            yield return operation;
            var mainScene = operation.Result.Scene;
            
            _mainGameContext = FindObjectOfType<GameContext>();

            // operation = Addressables.LoadSceneAsync(_uiScene, LoadSceneMode.Additive);
            // yield return operation;
            // var uiScene = operation.Result.Scene;
            
            // var gameContexts = FindObjectsOfType<GameContext>();
            // _mainGameContext = gameContexts.FirstOrDefault(g => g.gameObject.scene == mainScene);
            // _uiGameContext = gameContexts.FirstOrDefault(g => g.gameObject.scene == uiScene);
        }

        private void LoadGameData()
        {
            var characterLoader = ServiceLocator.GetService<CharacterMediator>();
            characterLoader.LoadData(_mainGameContext);
            
            // var moneyLoader = ServiceLocator.GetService<MoneyMediator>();
            // moneyLoader.LoadData(_uiGameContext);
            
            // var dataLoaders = ServiceLocator.GetServices<IGameDataLoader>();
            // foreach (var dataLoader in dataLoaders)
            // {
            //     dataLoader.LoadData(gameContext);
            // }
        }

        private void StartGame()
        {
            _mainGameContext.ConstructGame();
            _mainGameContext.StartGame();
            
            // _uiGameContext.ConstructGame();
            // _uiGameContext.StartGame();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveGameData();
            }
        }

        private void OnApplicationQuit()
        {
            SaveGameData();
        }

        private void SaveGameData()
        {
            if (!_applicationLoaded)
            {
                return;
            }

            var characterSaver = ServiceLocator.GetService<CharacterMediator>();
            characterSaver.SaveData(_mainGameContext);
            
            // var moneySaver = ServiceLocator.GetService<MoneyMediator>();
            // moneySaver.SaveData(_uiGameContext);
            
            // var dataSavers = ServiceLocator.GetServices<IGameDataSaver>();
            // foreach (var dataSaver in dataSavers)
            // {
            //     dataSaver.SaveData(gameContext);
            // }
        }

    }
}
