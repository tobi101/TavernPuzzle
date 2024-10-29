using TavernPuzzle.Scripts.Game.Gameplay.Services;
using TavernPuzzle.Scripts.Services;

namespace TavernPuzzle.Scripts.Game.Gameplay.Root.View
{
    public class UIGameplayRootViewModel
    {
        private readonly SomeGameplayService _someGameplayService;
        public UIGameplayRootViewModel(SomeGameplayService someGameplayService)
        {
            _someGameplayService = someGameplayService;
        }
    }
}