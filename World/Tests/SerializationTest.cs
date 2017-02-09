using NUnit.Framework;
using System;
using System.IO;

namespace World {
    [TestFixture()]
    public class SerializationTest {
        string _worldName = "TestWorld";
        string _fileName = "TestWorld.json";
        int _width = 16;
        int _height = 16;
        int _depth = 16;

        [SetUp()]
        public void Setup() {
            World w = new World(_width, _height, _depth, _worldName);
            w.Save("./");
        }

        [Test()]
        public void TestCase() {
            World loaded = World.LoadFromFile(_fileName);
            Assert.AreEqual(_width, loaded.Width);
            Assert.AreEqual(_height, loaded.Height);
            Assert.AreEqual(_depth, loaded.Depth);
        }

        [TearDown()]
        public void TearDown() {
            File.Delete(_fileName);
        }
    }
}

