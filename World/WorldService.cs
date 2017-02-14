using System.Threading.Tasks;
using World.Tile;
using World.Utility;

namespace World {
    internal class WorldService {

        public ITile[,,] GenerateTiles(int width, int height, int depth,
            int seaLevel, int shoreLine, double scaleX, double scaleY, int seed) {
            var gen = new LandscapeGenerator(width, height, depth, seaLevel,
                                             shoreLine, scaleX, scaleY, seed);
            return gen.GenerateTiles();
        }

        public World LoadWorld(string path) {
            return new LandscapeDAO().Load(path);
        }

        public void SaveWorld(World w, string path) {
            new LandscapeDAO().Save(w, path);
        }

        public void FillNullTilesWithAir(ITile[,,] tiles) {
            TileArrayManipulator.InflateNullTiles(tiles);
        }

        public ITile[] FlattenTileArray(ITile[,,] tiles) {
            return TileArrayManipulator.Flatten(tiles);
        }

    }
}
