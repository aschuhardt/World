using System;

namespace World.Tile {
    public class SandTile : TileBase {
        public SandTile(int x, int y, int z) : base(x, y, z, TileTypes.Sand) {
        }        
        public SandTile() : base(TileTypes.Sand) {
        }
    }
}

