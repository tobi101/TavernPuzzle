using BaCon;
using TavernPuzzle.Scripts.Game.Gameplay.Services;
using TavernPuzzle.Scripts.Services;

namespace TavernPuzzle.Scripts.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}