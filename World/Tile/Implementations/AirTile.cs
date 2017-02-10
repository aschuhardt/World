using System;

namespace World.Tile {
    public class AirTile : TileBase {
        public AirTile(int x, int y, int z) : base(x, y, z, TileTypes.Air) {
        }
        public AirTile() : base(TileTypes.Air) {
        }
    }
}

