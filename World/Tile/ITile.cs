using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using World.StaticEntity;

namespace World.Tile {
    public enum TileTypes {
        Air,
        Water,
        Grass,
        Sand
    }

    public interface ITile {
        TileTypes TileType { get; }
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }
        bool ShouldLoad { get; set; }
        string Serialized { get; }
    }
}

