using BaCon;
using TavernPuzzle.Scripts.Game.MainMenu.Services;
using TavernPuzzle.Scripts.Services;

namespace TavernPuzzle.Scripts.Game.MainMenu
{
    public static class MainMenuRegistrations
    {
        public static void Register(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeCommonService>())).AsSingle();
        }
    }
}