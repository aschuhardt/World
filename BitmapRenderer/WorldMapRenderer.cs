using System;
using System.Drawing;
using World.Tile;

namespace BitmapRenderer {
    public static class WorldMapRenderer {
        public enum RenderStyles {
            Depth,
            TileType
        }

        public static void RenderTopDownMap(World.World map, string filename, RenderStyles style, bool occludeWater = false) {
            Bitmap bmp = new Bitmap(map.Width, map.Height);

            for (int x = 0; x < map.Width; x++) {
                for (int y = 0; y < map.Height; y++) {

                    //ray-cast downward until we hit something that isn't air
                    for (int z = map.Depth - 1; z > 0; z--) {
                        ITile tile = map.Tiles[x, y, z];
                        if (tile.TileType != TileTypes.Air 
                            && (tile.TileType != TileTypes.Water || !occludeWater)) {
                            bmp.SetPixel(x, y, WorldMapRenderer.MapTileToColor(tile, style, map.Depth));
                            break;
                        }
                    }
                }
            }

            bmp.Save(filename);
        }

        private static Color MapTileToColor(ITile tile, RenderStyles style, int mapDepth) {
            switch (style) {
                case RenderStyles.Depth:
                    return MapDepthToColor(tile.Z, mapDepth);
                case RenderStyles.TileType:
                    return MapTileTypeToColor(tile.TileType);
                default:
                    return Color.White;
            }
        }

        private static int Map(this int value, double fromSource, double toSource, double fromTarget, double toTarget) {
            return Convert.ToInt32(((value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget));
        }

        private static Color MapDepthToColor(int tileDepth, int mapDepth) {
            int val = tileDepth.Map(0, mapDepth, 0, 255);
            return Color.FromArgb(val, val, val);
        }

        private static Color MapTileTypeToColor(TileTypes t) {
            switch (t) {
                case TileTypes.Water:
                    return Color.Blue;
                case TileTypes.Grass:
                    return Color.Green;
                case TileTypes.Stone:
                    return Color.Gray;
                case TileTypes.Dirt:
                    return Color.Brown;
                case TileTypes.Ice:
                    return Color.LightBlue;
                case TileTypes.Sand:
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }
    }
}
