using BaCon;

namespace TavernPuzzle.Scripts.Game.MainMenu.Root.View
{
    public static class MainMenuViewModelRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}