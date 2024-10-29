using System;
using UnityEngine;

namespace TavernPuzzle.Scripts.Game.State.Tiles
{
    [Serializable]
    public class TileEntity
    {
        public int Id;
        public string TypeId;
        public Vector2 Position;
        public int Level;
    }
}