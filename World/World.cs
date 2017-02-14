using System;
using World.Tile;

namespace World {
    [Serializable]
    public class World {
        public const float DEFAULT_SCALE_X = 10.0f;
        public const float DEFAULT_SCALE_Y = 10.0f;

        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int SeaLevel { get; set; }
        public int ShoreLine { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public int Seed { get; set; }

        public float OffsetX { get; set; }
        public float OffsetY { get; set; }

        public bool HasGeneratedTiles { get; set; }

        public ITile[,,] Tiles { get; private set; }

        public ITile[] SerializedTileArray {
            get {
                return new WorldService().FlattenTileArray(this.Tiles);
            }
            set {
                foreach (ITile t in value) {
                    this.SetTileAtLocation(t, t.X, t.Y, t.Z);
                }
                this.FillNullTilesWithAir();
            }
        }

        public World(int width, int height, int depth, int seaLevel, int shoreLine, string name = "World", bool generate = true) {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Name = name;
            this.SeaLevel = seaLevel;
            this.ShoreLine = shoreLine;
            this.Tiles = new ITile[this.Width, this.Height, this.Depth];
            this.ScaleX = DEFAULT_SCALE_X;
            this.ScaleY = DEFAULT_SCALE_Y;
            this.Seed = Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue);
            this.OffsetX = 0;
            this.OffsetY = 0;

            this.HasGeneratedTiles = false;

            if (generate) this.GenerateTiles();
        }

        /// <summary>
        /// Generates a world without generating tiles by default.  Don't use this, this is just for the JSON serializer.
        /// </summary>
        public World(int width, int height, int depth, int seaLevel, int shoreLine, string name)
            : this(width, height, depth, seaLevel, shoreLine, name, false) {
        }

        public World(int width, int height, int depth, string name = "World", bool generate = true)
            : this(width, height, depth, depth / 2, (depth / 2) + (depth / 8), name, generate) {
        }

        public ITile GetTileForDynamicEntity(IDynamicEntity ent) {
            return this.Tiles[ent.X, ent.Y, ent.Z];
        }

        public void SetTileAtLocation(ITile t, int x, int y, int z) {
            this.Tiles[x, y, z] = t;
        }

        public void Save(string outputDirectory) {
            new WorldService().SaveWorld(this, outputDirectory);
        }

        public static World LoadFromFile(string filename) {
            return new WorldService().LoadWorld(filename);
        }

        internal void FillNullTilesWithAir() {
            new WorldService().FillNullTilesWithAir(this.Tiles);
        }

        public void GenerateTiles() {
            this.HasGeneratedTiles = true;
            this.Tiles = new WorldService().GenerateTiles(this);
        }

        public void ClearTiles() {
            this.HasGeneratedTiles = false;
            Tiles = null;
            GC.Collect();
        }
    }
}

