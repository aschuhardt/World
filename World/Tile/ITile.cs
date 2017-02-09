using System;
using System.Collections.Generic;
using World.StaticEntity;

namespace World.Tile {
    public enum TileTypes {
        Air,
        Water,
        Grass,
        Stone,
        Dirt,
        Ice,
        Sand
    }

    public interface ITile {
        TileTypes TileType { get; }
        IList<IStaticEntity> StaticEntities { get; }
        int X { get; }
        int Y { get; }
        int Z { get; }
    }
}

