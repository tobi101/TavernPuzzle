using System;
using System.Linq;
using ObservableCollections;
using TavernPuzzle.Scripts.Game.State.Root;
using TavernPuzzle.Scripts.Services;
using UnityEngine;
using R3;
using TavernPuzzle.Scripts.Game.State.Tiles;

namespace TavernPuzzle.Scripts.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly GameStateProxy _gameState;
        private readonly SomeCommonService _someCommonService;

        public SomeGameplayService(GameStateProxy gameState, SomeCommonService someCommonService)
        {
            _gameState = gameState;
            _someCommonService = someCommonService;
            Debug.Log(GetType().Name + " has been created");
            
            gameState.Tiles.ForEach(t => Debug.Log($"Tile: {t.TypeId}"));
            gameState.Tiles.ObserveAdd().Subscribe(e => Debug.Log($"Tile added: {e.Value.TypeId}"));
            gameState.Tiles.ObserveRemove().Subscribe(e => Debug.Log($"Tile removed: {e.Value.TypeId}"));
            
            AddTile("One");
            AddTile("Two");
            AddTile("Three");
            
            RemoveTile("Three");
        }

        public void Dispose()
        {
            Debug.Log("Clean all subscriptions");
        }

        private void AddTile(string tileTypeId)
        {
            var tile = new TileEntity()
            {
                TypeId = tileTypeId,
            };
            var tileProxy = new TileEntityProxy(tile);
            _gameState.Tiles.Add(tileProxy);
        }
        
        private void RemoveTile(string tileTypeId)
        {
            var tileEntity = _gameState.Tiles.FirstOrDefault(t => t.TypeId == tileTypeId);

            if (tileEntity != null)
            {
                _gameState.Tiles.Remove(tileEntity);
            }
        }
    }
}