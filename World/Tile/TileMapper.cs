using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace World.Tile {
    internal static class TileMapper {
        public static ITile GetTileForType(TileTypes tt) {
            ITile output;
            switch (tt) {
                case TileTypes.Air:
                    output = new AirTile();
                    break;
                case TileTypes.Water:
                    output = new WaterTile();
                    break;
                case TileTypes.Grass:
                    output = new WaterTile();
                    break;
                case TileTypes.Sand:
                    output = new SandTile();
                    break;
                default:
                    output = new AirTile();
                    break;
            }
            return output;
        }
    }
}
