using System;

namespace World.Tile {
    [Serializable]
    public class WaterTile : TileBase {
        public WaterTile(int x, int y, int z) : base(x, y, z, TileTypes.Water) {
        }
        public WaterTile() : base(TileTypes.Water) {
        }
    }
}

