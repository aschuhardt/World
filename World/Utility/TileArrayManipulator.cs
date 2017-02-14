using System.Collections.Generic;
using World.Tile;

namespace World.Utility {
    internal static class TileArrayManipulator {
        /// <summary>
        /// Flattens a 3D array of ITile objects into a single-dimensional array.
        /// </summary>
        /// <param name="input">The 3D array to be flattened.</param>
        /// <returns>A one-dimensional array of ITile objects.</returns>
        public static ITile[] Flatten(ITile[,,] input) {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            int depth = input.GetLength(2);
            List<ITile> tArr = new List<ITile>();
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    for (int z = 0; z < depth; z++) {
                        if (input[x, y, z] != null) {
                            ITile t = input[x, y, z];
                            tArr.Add(t);
                        }
                    }
                }
            }
            return tArr.ToArray();
        }

        /// <summary>
        /// Replaces null ITile objects in a 3D array with instances of the AirTile object.
        /// </summary>
        /// <param name="input">The 3D array to be inflated.</param>
        public static void InflateNullTiles(ITile[,,] input) {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            int depth = input.GetLength(2);
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    for (int z = 0; z < depth; z++) {
                        if (input[x, y, z] == null) {
                            ITile t = new AirTile(x, y, z);
                            input[x, y, z] = t;
                        }
                    }
                }
            }
        }
    }
}
