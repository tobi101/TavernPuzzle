using R3;
using TavernPuzzle.Scripts.Game.State.Tiles;
using UnityEngine;

namespace TavernPuzzle.Scripts.Game.State.Root
{
    public class TileEntityProxy
    {
        public int Id { get; }
        public string TypeId { get; }
        
        public ReactiveProperty<Vector2> Position { get; }
        public ReactiveProperty<int> Level { get; }

        public TileEntityProxy(TileEntity tileEntity)
        {
            Id = tileEntity.Id;
            TypeId = tileEntity.TypeId;
            
            Position = new ReactiveProperty<Vector2>(tileEntity.Position);
            Level = new ReactiveProperty<int>(tileEntity.Level);

            Position.Skip(1).Subscribe(value => tileEntity.Position = value);
            Level.Skip(1).Subscribe(value => tileEntity.Level = value);
        }
    }
}