using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using BitmapRenderer;

namespace Visualizer {
    class WorldBindingSource {
        private const int DEFAULT_VALUE_WIDTH = 128;
        private const int DEFAULT_VALUE_HEIGHT = 128;
        private const int DEFAULT_VALUE_DEPTH = 32;
        private const int DEFAULT_VALUE_SEALEVEL = 16;
        private const int DEFAULT_VALUE_SHORELINE = 18;
        private const WorldMapRenderer.RenderStyles DEFAULT_VALUE_RENDERSTYLE = WorldMapRenderer.RenderStyles.Depth;
        private const bool DEFAULT_VALUE_OCCLUDE_WATER = false;

        private World.World _backingData;
        
        public string Name {
            get { return _backingData.Name; }
            set { _backingData.Name = value; }
        }

        public int Width {
            get { return _backingData.Width; }
            set { _backingData.Width = value; }
        }

        public int Height {
            get { return _backingData.Height; }
            set { _backingData.Height = value; }
        }

        public int Depth {
            get { return _backingData.Depth; }
            set { _backingData.Depth = value; }
        }

        public int SeaLevel {
            get { return _backingData.SeaLevel; }
            set { _backingData.SeaLevel = value; }
        }

        public int ShoreLine {
            get { return _backingData.ShoreLine; }
            set { _backingData.ShoreLine = value; }
        }

        public WorldMapRenderer.RenderStyles ImageRenderStyle { get; set; }
        public bool OccludeWater { get; set; }
        public int Seed { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }

        public Image RenderedImage {
            get {
                _backingData.GenerateTiles(this.ScaleX, this.ScaleY, this.Seed);
                Bitmap bmp = WorldMapRenderer.RenderTopDownMap(_backingData, this.ImageRenderStyle, this.OccludeWater);
                _backingData.ClearTiles();
                return bmp;
            }
        }

        public void Save(string path) {
            _backingData.Save(path);
        }

        public World.World Load(string path) {
            return World.World.LoadFromFile(path);
        }

        public WorldBindingSource() {
            _backingData = new World.World(DEFAULT_VALUE_WIDTH, DEFAULT_VALUE_HEIGHT, DEFAULT_VALUE_DEPTH, DEFAULT_VALUE_SEALEVEL, DEFAULT_VALUE_SHORELINE, "World", false);
            setDefaultRenderParams();
        }

        public WorldBindingSource(World.World w) {
            this._backingData = w;
            setDefaultRenderParams();
        }

        private void setDefaultRenderParams() {
            this.ScaleX = World.World.DEFAULT_SCALE_X;
            this.ScaleY = World.World.DEFAULT_SCALE_Y;
            this.Seed = Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue);
            this.ImageRenderStyle = DEFAULT_VALUE_RENDERSTYLE;
            this.OccludeWater = DEFAULT_VALUE_OCCLUDE_WATER;
        }
    }
}
