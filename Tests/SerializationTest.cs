using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using World.Tile;

namespace World {
    [TestFixture()]
    public class SerializationTest {
        string _worldName = "TestWorld";
        string _fileName = "TestWorld.json";
        int _width = 32;
        int _height = 32;
        int _depth = 4;

        World _baseWorld;

        [SetUp()]
        public void Setup() {
            _baseWorld = new World(_width, _height, _depth, _worldName);

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

