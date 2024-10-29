using System.Linq;
using ObservableCollections;
using R3;
using TavernPuzzle.Scripts.Game.State.Tiles;
using UnityEngine.Tilemaps;

namespace TavernPuzzle.Scripts.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<TileEntityProxy> Tiles { get; } = new();
        
        public GameStateProxy(GameState gameState)
        {
            gameState.Tiles.ForEach(tile => Tiles.Add(new TileEntityProxy(tile)));

            Tiles.ObserveAdd().Subscribe(e =>
            {
                var addedTileEntity = e.Value;
                gameState.Tiles.Add(new TileEntity
                {
                    Id = addedTileEntity.Id,
                    TypeId = addedTileEntity.TypeId,
                    Level = addedTileEntity.Level.Value,
                    Position = addedTileEntity.Position.Value
                });
            });

            Tiles.ObserveRemove().Subscribe(e =>
            {
                var removedTileEntityProxy = e.Value;
                var removedTileEntity = gameState.Tiles.FirstOrDefault(b => b.Id == removedTileEntityProxy.Id);
                gameState.Tiles.Remove(removedTileEntity);
            });
        }
    }
}