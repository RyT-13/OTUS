using System.Collections;
using GameData.Character;
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
        

        private bool applicationLoaded;

        private GameContext gameContext;

        [Button]
        public void LoadApplication()
        {
            if (!applicationLoaded)
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
            applicationLoaded = true;
        }

        private void InstallServices()
        {
            serviceInstaller.InstallServices();
            ServiceInjector.ResolveDependencies();
        }

        private IEnumerator LoadGameScene()
        {
            // const string sceneId = "Scenes/GameScene";
            var operation = Addressables.LoadSceneAsync(_gameScene, LoadSceneMode.Additive);
            yield return operation;
            
            gameContext = FindObjectOfType<GameContext>();
        }

        private void LoadGameData()
        {
            var dataSaver = ServiceLocator.GetService<CharacterMediator>();
            dataSaver.LoadData(gameContext);
            
            // var dataLoaders = ServiceLocator.GetServices<IGameDataLoader>();
            // foreach (var dataLoader in dataLoaders)
            // {
            //     dataLoader.LoadData(gameContext);
            // }
        }

        private void StartGame()
        {
            gameContext.ConstructGame();
            gameContext.StartGame();
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
            if (!applicationLoaded)
            {
                return;
            }

            var dataSaver = ServiceLocator.GetService<CharacterMediator>();
            dataSaver.SaveData(gameContext);
            
            // var dataSavers = ServiceLocator.GetServices<IGameDataSaver>();
            // foreach (var dataSaver in dataSavers)
            // {
            //     dataSaver.SaveData(gameContext);
            // }
        }

    }
}
