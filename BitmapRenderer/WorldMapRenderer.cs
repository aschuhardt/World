using System;
using System.Drawing;
using World.Tile;
using System.Threading.Tasks;

namespace BitmapRenderer {
    public static class WorldMapRenderer {
        public enum CrossSectionAxis {
            XAxis,
            YAxis,
            ZAxis
        }

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

        public static void RenderCrossSectionMap(World.World map, string filename, int plane, RenderStyles style, CrossSectionAxis axis) {
            Bitmap bmp;

            ITile[,] renderPlane;

            switch (axis) {
                case CrossSectionAxis.XAxis:
                    bmp = new Bitmap(map.Width, map.Depth);
                    renderPlane = new ITile[map.Width, map.Depth]; //[X, Z]
                    for (int x = 0; x < map.Width; x++) {
                        for (int z = 0; z < map.Depth; z++) {
                            renderPlane[x, z] = map.Tiles[x, plane, z];
                        }
                    }
                    break;
                case CrossSectionAxis.YAxis:
                    bmp = new Bitmap(map.Height, map.Depth);
                    renderPlane = new ITile[map.Height, map.Depth]; //[Y, Z]
                    for (int y = 0; y < map.Height; y++) {
                        for (int z = 0; z < map.Depth; z++) {
                            renderPlane[y, z] = map.Tiles[plane, y, z];
                        }
                    }
                    break;
                case CrossSectionAxis.ZAxis:
                    bmp = new Bitmap(map.Width, map.Height);
                    renderPlane = new ITile[map.Width, map.Height]; //[X, Y]
                    for (int x = 0; x < map.Width; x++) {
                        for (int y = 0; y < map.Height; y++) {
                            renderPlane[x, y] = map.Tiles[x, y, plane];
                        }
                    }
                    break;
                default:
                    throw new Exception($"Unrecognized axis {axis.ToString()}!");
            }

            for (int x = 0; x < bmp.Width; x++) {
                for (int y = 0; y < bmp.Height; y++) {
                    bmp.SetPixel(x, y, MapTileToColor(renderPlane[x, y], style, map.Depth));
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
                case TileTypes.Sand:
                    return Color.Yellow;
                default:
                    return Color.White;
            }
        }
    }
}
