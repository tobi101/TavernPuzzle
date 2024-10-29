using UnityEngine;

namespace TavernPuzzle.Scripts.Services
{
    public class SomeCommonService
    {
        // Например, провайдер состояния, или провайдер настроек, сервис аналитики, платежки и пр.
        public SomeCommonService()
        {
            Debug.Log(GetType().Name + " has been created");
        }
        
        
    }
}