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
        IList<IStaticEntity> StaticEntities { get; }
        int X { get; set; }
        int Y { get; set; }
        int Z { get; set; }
        [JsonIgnore]
        string Serialized { get; }
    }
}

