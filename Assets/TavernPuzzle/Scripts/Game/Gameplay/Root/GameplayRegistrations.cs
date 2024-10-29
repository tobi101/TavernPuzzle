using BaCon;
using TavernPuzzle.Scripts.Game.Gameplay.Services;
using TavernPuzzle.Scripts.Game.State;
using TavernPuzzle.Scripts.Services;

namespace TavernPuzzle.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(
                c.Resolve<IGameStateProvider>().GameState,
                c.Resolve<SomeCommonService>())
            ).AsSingle();
        }
    }
}