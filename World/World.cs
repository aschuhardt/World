using System;
using World.Tile;

namespace World {
    public class World {
        public string Name { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Depth { get; private set; }

        public int SeaLevel { get; private set; }

        public int ShoreLine { get; private set; }

        public ITile[,,] Tiles { get; private set; }

        public World (int width, int height, int depth, int seaLevel, int shoreLine, string name = "World") {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
            this.Name = name;
            this.SeaLevel = seaLevel;
            this.ShoreLine = shoreLine;
            this.GenerateTiles();
        }

        public World (int width, int height, int depth, string name = "World") 
            : this(width, height, depth, depth / 2, (depth / 2) + (depth / 8), name) {
        }

        public ITile GetTileForDynamicEntity(IDynamicEntity ent) {
            return this.Tiles [ent.X, ent.Y, ent.Z];
        }

        private void GenerateTiles() {
            this.Tiles = new ITile[this.Width, this.Height, this.Depth];
            for (int x = 0; x < this.Width; x++) {
                for (int y = 0; y < this.Height; y++) {
                    for (int z = 0; z < this.Depth; z++) {

                    }
                }
            }
        }
    }
}

