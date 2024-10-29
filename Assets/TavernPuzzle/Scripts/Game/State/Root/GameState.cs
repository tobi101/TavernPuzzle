using System;
using System.Collections.Generic;
using TavernPuzzle.Scripts.Game.State.Tiles;

namespace TavernPuzzle.Scripts.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public List<TileEntity> Tiles;
    }
}