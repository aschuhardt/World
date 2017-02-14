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

        private bool _isDirty;
        private Bitmap _cachedImage;
        
        public string Name {
            get { return _backingData.Name; }
            set {
                _backingData.Name = value;
                _isDirty = true;
            }
        }

        public int Width {
            get { return _backingData.Width; }
            set {
                _backingData.Width = value;
                _isDirty = true;
            }
        }

        public int Height {
            get { return _backingData.Height; }
            set {
                _backingData.Height = value;
                _isDirty = true;
            }
        }

        public int Depth {
            get { return _backingData.Depth; }
            set {
                _backingData.Depth = value;
                _isDirty = true;
            }
        }

        public int SeaLevel {
            get { return _backingData.SeaLevel; }
            set {
                _backingData.SeaLevel = value;
                _isDirty = true;
            }
        }

        public int ShoreLine {
            get { return _backingData.ShoreLine; }
            set {
                _backingData.ShoreLine = value;
                _isDirty = true;
            }
        }

        public float ScaleX {
            get { return _backingData.ScaleX; }
            set {
                _backingData.ScaleX = value;
                _isDirty = true;
            }
        }

        public float ScaleY {
            get { return _backingData.ScaleY; }
            set {
                _backingData.ScaleY = value;
                _isDirty = true;
            }
        }

        public int Seed {
            get { return _backingData.Seed; }
            set {
                _backingData.Seed = value;
                _isDirty = true;
            }
        }

        public WorldMapRenderer.RenderStyles ImageRenderStyle { get; set; }
        public bool OccludeWater { get; set; }

        public Image RenderedImage {
            get {
                if (_isDirty) {
                    _isDirty = false;
                    _backingData.GenerateTiles();
                    Bitmap bmp = WorldMapRenderer.RenderTopDownMap(_backingData, this.ImageRenderStyle, this.OccludeWater);
                    _backingData.ClearTiles();
                    _cachedImage = bmp;
                }
                return _cachedImage;
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
            _isDirty = true;
        }

        public WorldBindingSource(World.World w) {
            this._backingData = w;
            setDefaultRenderParams();
            _isDirty = true;
        }

        private void setDefaultRenderParams() {
            this.ImageRenderStyle = DEFAULT_VALUE_RENDERSTYLE;
            this.OccludeWater = DEFAULT_VALUE_OCCLUDE_WATER;
        }
    }
}
