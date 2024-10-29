using System.Collections.Generic;
using R3;
using TavernPuzzle.Scripts.Game.State.Root;
using TavernPuzzle.Scripts.Game.State.Tiles;
using UnityEngine;

namespace TavernPuzzle.Scripts.Game.State
{
    public class PlayerPrefsGameStateProvider : IGameStateProvider
    {
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        private const string GAME_SETTINGS_STATE_KEY = nameof(GAME_SETTINGS_STATE_KEY);
        public GameStateProxy GameState { get; private set; }
        public GameSettingsStateProxy SettingsState { get; private set; }
        
        private GameState _gameStateOrigin;
        private GameSettingsState _gameSettingsStateOrigin;
        
        public Observable<GameStateProxy> LoadGameState()
        {
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
            {
                GameState = CreateGameStateFromSettings();
                Debug.Log("Game State created from settings: " + JsonUtility.ToJson(_gameStateOrigin, true));

                SaveGameState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameStateOrigin = JsonUtility.FromJson<GameState>(json);
                GameState = new GameStateProxy(_gameStateOrigin);
                
                Debug.Log("Game State loaded: " + json);
            }

            return Observable.Return(GameState);
        }

        public Observable<GameSettingsStateProxy> LoadSettingsState()
        {
            if (!PlayerPrefs.HasKey(GAME_SETTINGS_STATE_KEY))
            {
                SettingsState = CreateGameSettingsStateFromSettings();
                SaveSettingsState();
            }
            else
            {
                var json = PlayerPrefs.GetString(GAME_SETTINGS_STATE_KEY);
                _gameSettingsStateOrigin = JsonUtility.FromJson<GameSettingsState>(json);
                SettingsState = new GameSettingsStateProxy(_gameSettingsStateOrigin);
            }

            return Observable.Return(SettingsState);
        }

        public Observable<bool> SaveGameState()
        {
            var json = JsonUtility.ToJson(_gameStateOrigin, true);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }
        
        public Observable<bool> SaveSettingsState()
        {
            var json = JsonUtility.ToJson(_gameSettingsStateOrigin, true);
            PlayerPrefs.SetString(GAME_SETTINGS_STATE_KEY, json);
            
            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState()
        {
            GameState = CreateGameStateFromSettings();
            SaveGameState();
            
            return Observable.Return(true);
        }
        
        public Observable<GameSettingsStateProxy> ResetSettingsState()
        {
            SettingsState = CreateGameSettingsStateFromSettings();
            SaveSettingsState();
            
            return Observable.Return(SettingsState);
        }
        
        private GameStateProxy CreateGameStateFromSettings()
        {
            // Состояние по умолчанию из настроект, мы делаем фейк
            _gameStateOrigin = new GameState
            {
                Tiles = new List<TileEntity>
                {
                    new()
                    {
                        TypeId = "PRO100"
                    },
                    new()
                    {
                        TypeId = "STARIK"
                    }
                }
            };
            
            return new GameStateProxy(_gameStateOrigin);
        }
        
        private GameSettingsStateProxy CreateGameSettingsStateFromSettings()
        {
            _gameSettingsStateOrigin = new GameSettingsState()
            {
                MusicVolume = 8,
                SFXVolume = 8
            };
            
            return new GameSettingsStateProxy(_gameSettingsStateOrigin);
        }
    }
}