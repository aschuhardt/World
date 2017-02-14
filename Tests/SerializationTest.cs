using NUnit.Framework;
using System.IO;
using BitmapRenderer;

namespace World {
    [TestFixture()]
    public class SerializationTest {
        string _worldName = "TestWorld";
        int _width = 256;
        int _height = 256;
        int _depth = 64;

        World _baseWorld;

        [SetUp()]
        public void Setup() {
            _baseWorld = new World(_width, _height, _depth, _worldName);
            _baseWorld.GenerateTiles();

            //save a bitmap render because why not
            WorldMapRenderer.SaveRenderedTopDownMap(_baseWorld, "map_depth.bmp", WorldMapRenderer.RenderStyles.Depth, true);
            WorldMapRenderer.SaveRenderedTopDownMap(_baseWorld, "map_type.bmp", WorldMapRenderer.RenderStyles.TileType, false);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_x_type.bmp", _height / 2, WorldMapRenderer.RenderStyles.TileType, WorldMapRenderer.CrossSectionAxis.XAxis);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_x_depth.bmp", _height / 2, WorldMapRenderer.RenderStyles.Depth, WorldMapRenderer.CrossSectionAxis.XAxis);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_y_type.bmp", _width / 2, WorldMapRenderer.RenderStyles.TileType, WorldMapRenderer.CrossSectionAxis.YAxis);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_y_depth.bmp", _width / 2, WorldMapRenderer.RenderStyles.Depth, WorldMapRenderer.CrossSectionAxis.YAxis);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_z_type.bmp", _depth / 2, WorldMapRenderer.RenderStyles.TileType, WorldMapRenderer.CrossSectionAxis.ZAxis);
            WorldMapRenderer.RenderCrossSectionMap(_baseWorld, "map_slice_z_depth.bmp", _depth / 2, WorldMapRenderer.RenderStyles.Depth, WorldMapRenderer.CrossSectionAxis.ZAxis);

            _baseWorld.Save("./");
        }

        [Test()]
        public void TestCase() {
            World loaded = World.LoadFromFile(_worldName);
            loaded.GenerateTiles();
            Assert.AreEqual(_width, loaded.Width);
            Assert.AreEqual(_height, loaded.Height);
            Assert.AreEqual(_depth, loaded.Depth);

            for (int x = 0; x < _width; x++) {
                for (int y = 0; y < _height; y++) {
                    for (int z = 0; z < _depth; z++) {
                        Assert.AreEqual(_baseWorld.Tiles[x, y, z].TileType, loaded.Tiles[x, y, z].TileType);
                    }
                }
            }
        }

        [TearDown()]
        public void TearDown() {
            File.Delete(_worldName);
        }
    }
}

