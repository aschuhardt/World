using World.Tile;
using World.Utility;

namespace World {
    internal class WorldService {

        public ITile[,,] GenerateTiles(World world) {

            var gen = new LandscapeGenerator(world);
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
