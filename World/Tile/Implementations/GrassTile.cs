using System;

namespace World.Tile {
    public class GrassTile : TileBase {
        public GrassTile(int x, int y, int z) : base(x, y, z, TileTypes.Grass) {
        }
        public GrassTile() : base(TileTypes.Grass) {
        }
    }
}

