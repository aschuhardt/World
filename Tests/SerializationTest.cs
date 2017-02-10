using NUnit.Framework;
using System.IO;
using BitmapRenderer;

namespace World {
    [TestFixture()]
    public class SerializationTest {
        string _worldName = "TestWorld";
        string _fileName = "TestWorld.json";
        int _width = 128;
        int _height = 128;
        int _depth = 16;

        World _baseWorld;

        [SetUp()]
        public void Setup() {
            _baseWorld = new World(_width, _height, _depth, _worldName);

            //save a bitmap render because why not
            WorldMapRenderer.RenderTopDownMap(_baseWorld, "map_depth.bmp", WorldMapRenderer.RenderStyles.Depth, true);
            WorldMapRenderer.RenderTopDownMap(_baseWorld, "map_type.bmp", WorldMapRenderer.RenderStyles.TileType, true);

            _baseWorld.Save("./");
        }

        [Test()]
        public void TestCase() {
            World loaded = World.LoadFromFile(_fileName);
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
            File.Delete(_fileName);
        }
    }
}

