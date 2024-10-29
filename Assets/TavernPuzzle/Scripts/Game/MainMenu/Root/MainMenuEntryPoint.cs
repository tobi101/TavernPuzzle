using BaCon;
using R3;
using TavernPuzzle.Scripts.Game.Gameplay.Root.View;
using TavernPuzzle.Scripts.Game.MainMenu.Root.View;
using UnityEngine;


namespace TavernPuzzle.Scripts.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

        public Observable<MainMenuExitParams> Run(DIContainer mainMenuContainer, MainMenuEnterParams enterParams)
        {
            MainMenuRegistrations.Register(mainMenuContainer, enterParams);
            
            var mainMenuViewModelsContainer = new DIContainer(mainMenuContainer);
            MainMenuViewModelRegistrations.Register(mainMenuViewModelsContainer);
            
            ///

            // For test
            mainMenuViewModelsContainer.Resolve<UIMainMenuRootViewModel>();
            
            var uIRoot = mainMenuContainer.Resolve<UIRootView>();
            
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uIRoot.AttachSceneUI(uiScene.gameObject);

            var exitSignalSubj = new Subject<Unit>();
            uiScene.Bind(exitSignalSubj);

            Debug.Log($"MAIN MENU ENTRY POINT: Run main menu scene. Results: {enterParams?.Result}");

            var saveFileName = "ololo.save";
            var levelNumber = Random.Range(0, 300);
            var gameplayEnterParams = new GameplayEnterParams(saveFileName, levelNumber);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);

            var exitToGameplaySceneSignal = exitSignalSubj.Select(_ => mainMenuExitParams);

            return exitToGameplaySceneSignal;
        }
    }
}
